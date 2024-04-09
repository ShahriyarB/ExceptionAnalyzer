using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.ReSharper.Psi;
using ExceptionAnalyzer;
using ExceptionAnalyzer.Highlightings;
using ExceptionAnalyzer.Models;
using ExceptionAnalyzer.Models.ExceptionsOrigins;
using ExceptionAnalyzer.Settings;

namespace ExceptionAnalyzer.Analyzers;

/// <summary>Analyzes throw statements and checks that exceptions thrown outside are documented.</summary>
internal class IsThrownExceptionDocumentedAnalyzer : AnalyzerBase
{
    /// <summary>Performs analyze of <paramref name="thrownException"/>.</summary>
    /// <param name="thrownException">Thrown exception to analyze.</param>
    public override void Visit(ThrownExceptionModel thrownException)
    {
        if (thrownException == null)
            return;

        if (!thrownException.AnalyzeUnit.IsInspectionRequired || thrownException.IsCaught || thrownException.IsExceptionDocumented)
            return;

        var isOptional = IsSubtypeDocumented(thrownException) ||
                         IsThrownExceptionSubclassOfOptionalException(thrownException) ||
                         IsThrownExceptionThrownFromExcludedMethod(thrownException) ||
                         thrownException.IsThrownFromAnonymousMethod;

        if (thrownException.IsEventInvocationException)
        {
            if (ServiceLocator.Settings.DelegateInvocationsMayThrowExceptions)
            {
                var highlighting = new EventExceptionNotDocumentedHighlighting(thrownException);
                ServiceLocator.StageProcess.AddHighlighting(highlighting, thrownException.DocumentRange);
            }
        }
        else
        {
            var highlighting = isOptional
                ? new ExceptionNotDocumentedOptionalHighlighting(thrownException)
                : new ExceptionNotDocumentedHighlighting(thrownException);
            ServiceLocator.StageProcess.AddHighlighting(highlighting, thrownException.DocumentRange);
        }
    }

    private bool IsSubtypeDocumented(ThrownExceptionModel thrownException)
    {
        if (thrownException.IsThrownFromThrowStatement)
        {
            if (ServiceLocator.Settings.IsDocumentationOfExceptionSubtypeSufficientForThrowStatements && thrownException.IsExceptionOrSubtypeDocumented)
                return true;
        }
        else
        {
            if (ServiceLocator.Settings.IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions && thrownException.IsExceptionOrSubtypeDocumented)
                return true;
        }

        return false;
    }

    private bool IsThrownExceptionSubclassOfOptionalException(ThrownExceptionModel thrownExceptionModel)
    {
        var optionalExceptions = ServiceLocator.Settings.GetOptionalExceptions();

        if (thrownExceptionModel.IsThrownFromThrowStatement)
            return optionalExceptions.Any(e => e.ReplacementType != OptionalExceptionReplacementType.InvocationOnly &&
                                               thrownExceptionModel.ExceptionType.IsSubtypeOf(e.ExceptionType));
        else
            return optionalExceptions.Any(e => e.ReplacementType != OptionalExceptionReplacementType.ThrowOnly &&
                                               thrownExceptionModel.ExceptionType.IsSubtypeOf(e.ExceptionType));
    }

    private bool IsThrownExceptionThrownFromExcludedMethod(ThrownExceptionModel thrownException)
    {
        var parent = thrownException.ExceptionsOrigin as ReferenceExpressionModel;
        if (parent != null)
        {
            var node = parent.Node;
            var resolveResult = node.Reference.Resolve();
            if (resolveResult != null)
            {
                var element = resolveResult.DeclaredElement as IXmlDocIdOwner;
                if (element != null && (resolveResult.DeclaredElement is IMethod || resolveResult.DeclaredElement is IProperty))
                {
                    // remove generic placeholders ("`1") and method signature ("(...)")
                    var fullMethodName = Regex.Replace(element.XMLDocId.Substring(2), "(`+[0-9]+)|(\\(.*?\\))", ""); // TODO: merge with other

                    var excludedMethods = ServiceLocator.Settings.GetOptionalMethodExceptions();
                    return excludedMethods.Any(t => t.FullMethodName == fullMethodName && t.IsSupertypeOf(thrownException));
                }
            }
        }
        return false;
    }        
}
using System;
using JetBrains.ReSharper.Psi.CSharp;
using ExceptionAnalyzer.Models;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ExceptionAnalyzer.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "ExceptionAnalyzer.ExceptionNotDocumentedOptional",
    "ExceptionAnalyzer.ExceptionNotDocumentedOptional",
    Severity.HINT
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class ExceptionNotDocumentedOptionalHighlighting : HighlightingBase
{
    public const string Id = "ExceptionNotDocumentedOptional";

    /// <summary>Initializes a new instance of the <see cref="ExceptionNotDocumentedOptionalHighlighting"/> class. </summary>
    /// <param name="thrownException">The thrown exception. </param>
    internal ExceptionNotDocumentedOptionalHighlighting(ThrownExceptionModel thrownException)
    {
        ThrownException = thrownException;
    }

    /// <summary>Gets the thrown exception. </summary>
    internal ThrownExceptionModel ThrownException { get; private set; }

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get
        {
            var exceptionType = ThrownException.ExceptionType;
            var exceptionTypeName = exceptionType != null ? exceptionType.GetClrName().FullName : "[NOT RESOLVED]";
            return Constants.OptionalPrefix + String.Format(AnalyzerResources.HighlightNotDocumentedExceptions, exceptionTypeName);
        }
    }
}
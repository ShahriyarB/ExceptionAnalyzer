using System;
using JetBrains.ReSharper.Psi.CSharp;
using ExceptionAnalyzer.Models;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ExceptionAnalyzer.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "ExceptionAnalyzer.ExceptionNotThrownOptional",
    "ExceptionAnalyzer.ExceptionNotThrownOptional",
    Severity.HINT
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class ExceptionNotThrownOptionalHighlighting : HighlightingBase
{
    public const string Id = "ExceptionNotThrownOptional";

    /// <summary>Initializes a new instance of the <see cref="ExceptionNotThrownOptionalHighlighting"/> class. </summary>
    /// <param name="exceptionDocumentation">The exception documentation. </param>
    internal ExceptionNotThrownOptionalHighlighting(ExceptionDocCommentModel exceptionDocumentation)
    {
        ExceptionDocumentation = exceptionDocumentation;
    }

    /// <summary>Gets the exception documentation. </summary>
    internal ExceptionDocCommentModel ExceptionDocumentation { get; private set; }

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get
        {
            return Constants.OptionalPrefix + String.Format(
                AnalyzerResources.HighlightNotThrownDocumentedExceptions, ExceptionDocumentation.ExceptionType.GetClrName().FullName);
        }
    }
}
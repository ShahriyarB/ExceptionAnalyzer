using System;
using ExceptionAnalyzer;
using JetBrains.ReSharper.Psi.CSharp;
using ReSharper.Exceptional.Models;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ReSharper.Exceptional.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "Exceptional.ExceptionNotThrown",
    "Exceptional.ExceptionNotThrown",
    Severity.WARNING
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class ExceptionNotThrownHighlighting : ExceptionNotThrownOptionalHighlighting
{
    public new const string Id = "ExceptionNotThrown";

    /// <summary>Initializes a new instance of the <see cref="ExceptionNotThrownHighlighting"/> class. </summary>
    /// <param name="exceptionDocumentation">The exception documentation. </param>
    internal ExceptionNotThrownHighlighting(ExceptionDocCommentModel exceptionDocumentation)
        : base(exceptionDocumentation)
    {
    }

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get
        {
            return String.Format(AnalyzerResources.HighlightNotThrownDocumentedExceptions, ExceptionDocumentation.ExceptionType.GetClrName().FullName);
        }
    }
}
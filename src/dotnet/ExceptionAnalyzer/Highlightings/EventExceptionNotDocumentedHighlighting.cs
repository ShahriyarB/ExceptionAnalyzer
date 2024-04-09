using JetBrains.ReSharper.Psi.CSharp;
using ExceptionAnalyzer.Models;

using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ExceptionAnalyzer.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "ExceptionAnalyzer.EventExceptionNotDocumented",
    "ExceptionAnalyzer.EventExceptionNotDocumented",
    Severity.WARNING
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class EventExceptionNotDocumentedHighlighting : ExceptionNotDocumentedHighlighting
{
    public new const string Id = "EventExceptionNotDocumented";

    /// <summary>Initializes a new instance of the <see cref="EventExceptionNotDocumentedHighlighting"/> class. </summary>
    /// <param name="thrownException">The thrown exception. </param>
    internal EventExceptionNotDocumentedHighlighting(ThrownExceptionModel thrownException)
        : base(thrownException)
    {
    }

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get { return AnalyzerResources.HighlightEventNotDocumentedExceptions; }
    }
}
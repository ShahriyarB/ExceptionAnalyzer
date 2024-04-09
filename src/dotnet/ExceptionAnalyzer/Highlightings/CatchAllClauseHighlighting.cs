using System;
using ExceptionAnalyzer;
using JetBrains.ReSharper.Psi.CSharp;

using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ExceptionAnalyzer.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "Exceptional.CatchAllClause",
    "Exceptional.CatchAllClause",
    Severity.WARNING
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class CatchAllClauseHighlighting : HighlightingBase
{
    public const string Id = "CatchAllClause";

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get { return String.Format(AnalyzerResources.HighlightCatchAllClauses); }
    }
}
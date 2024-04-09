using ExceptionAnalyzer;
using ExceptionAnalyzer.Highlightings;
using ExceptionAnalyzer.Models;

namespace ExceptionAnalyzer.Analyzers;

/// <summary>Analyzes a catch clause and checks if it is not catch-all clause.</summary>
internal class CatchAllClauseAnalyzer : AnalyzerBase
{
    /// <summary>Performs analyze of <paramref name="catchClause"/>.</summary>
    /// <param name="catchClause">Catch clause to analyze.</param>
    public override void Visit(CatchClauseModel catchClause)
    {
        if (catchClause.IsCatchAll)
            ServiceLocator.StageProcess.AddHighlighting(new CatchAllClauseHighlighting(), catchClause.DocumentRange);
    }
}
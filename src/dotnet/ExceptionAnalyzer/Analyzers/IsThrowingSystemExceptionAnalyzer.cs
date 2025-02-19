using ExceptionAnalyzer.Highlightings;
using ExceptionAnalyzer.Models;

namespace ExceptionAnalyzer.Analyzers;

/// <summary>
/// Analyzes whether a throw statement throws System.Exception.
/// </summary>
internal class IsThrowingSystemExceptionAnalyzer : AnalyzerBase
{
    /// <summary>
    /// Performs analyze of <paramref name="thrownException"/>.
    /// </summary>
    /// <param name="thrownException">
    /// Thrown exception to analyze.
    /// </param>
    public override void Visit(ThrownExceptionModel thrownException)
    {
        // add a squiggle if the throwing a Exception (new Exception())
        // throw; statements are ignored
        if (thrownException.IsThrownFromThrowStatement && 
            thrownException.FullName == "System.Exception" &&
            !thrownException.IsRethrow)
        {
            var highlight = new ThrowingSystemExceptionHighlighting();
            var range = thrownException.DocumentRange;

            ServiceLocator.StageProcess.AddHighlighting(highlight, range);
        }
    }
}
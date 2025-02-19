using JetBrains.ReSharper.Psi.CSharp;
using ExceptionAnalyzer.Models.ExceptionsOrigins;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace ExceptionAnalyzer.Highlightings;

[RegisterConfigurableSeverity(Id, Constants.CompoundName, HighlightingGroupIds.BestPractice,
    "ExceptionAnalyzer.ThrowFromCatchWithNoInnerException",
    "ExceptionAnalyzer.ThrowFromCatchWithNoInnerException",
    Severity.WARNING
)]
[ConfigurableSeverityHighlighting(Id, CSharpLanguage.Name)]
public class ThrowFromCatchWithNoInnerExceptionHighlighting : HighlightingBase
{
    public const string Id = "ThrowFromCatchWithNoInnerException";

    /// <summary>Initializes a new instance of the <see cref="ThrowFromCatchWithNoInnerExceptionHighlighting"/> class. </summary>
    /// <param name="throwStatement">The throw statement. </param>
    internal ThrowFromCatchWithNoInnerExceptionHighlighting(ThrowStatementModel throwStatement)
    {
        ThrowStatement = throwStatement;
    }

    /// <summary>Initializes a new instance of the <see cref="ThrowFromCatchWithNoInnerExceptionHighlighting"/> class. </summary>
    /// <param name="throwExpression">The throw expression. </param>
    internal ThrowFromCatchWithNoInnerExceptionHighlighting(ThrowExpressionModel throwExpression)
    {
        ThrowExpression = throwExpression;
    }

    /// <summary>Gets the throw statement. </summary>
    internal ThrowStatementModel ThrowStatement { get; private set; }

    /// <summary>Gets the throw expression. </summary>
    internal ThrowExpressionModel ThrowExpression { get; private set; }

    /// <summary>Gets the message which is shown in the editor. </summary>
    protected override string Message
    {
        get { return AnalyzerResources.HighlightThrowingFromCatchWithoutInnerException; }
    }
}
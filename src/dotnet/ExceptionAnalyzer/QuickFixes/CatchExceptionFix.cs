using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.TextControl;
using ExceptionAnalyzer.Highlightings;
using JetBrains.ReSharper.Feature.Services.QuickFixes;

namespace ExceptionAnalyzer.QuickFixes;

[QuickFix]
internal class CatchExceptionFix : SingleActionFix
{
    private ExceptionNotDocumentedOptionalHighlighting Error { get; set; }

    public CatchExceptionFix(ExceptionNotDocumentedOptionalHighlighting error)
    {
        Error = error;
    }

    public override string Text
    {
        get { return String.Format(AnalyzerResources.QuickFixCatchException, Error.ThrownException.ExceptionType.GetClrName().FullName); }
    }

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        var exceptionsOriginModel = Error.ThrownException.ExceptionsOrigin;

        var nearestTryBlock = exceptionsOriginModel.ContainingBlock.FindNearestTryStatement();
        if (nearestTryBlock == null)
            exceptionsOriginModel.SurroundWithTryBlock(Error.ThrownException.ExceptionType);
        else
            nearestTryBlock.AddCatchClause(Error.ThrownException.ExceptionType);

        return null;
    }
}
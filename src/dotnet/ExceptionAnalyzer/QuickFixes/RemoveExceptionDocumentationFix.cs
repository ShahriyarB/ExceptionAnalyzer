using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.TextControl;
using ExceptionAnalyzer.Highlightings;
using JetBrains.ReSharper.Feature.Services.QuickFixes;

namespace ExceptionAnalyzer.QuickFixes;

[QuickFix]
internal class RemoveExceptionDocumentationFix : SingleActionFix
{
    private ExceptionNotThrownHighlighting Error { get; set; }

    public RemoveExceptionDocumentationFix(ExceptionNotThrownHighlighting error)
    {
        Error = error;
    }

    public override string Text
    {
        get { return AnalyzerResources.QuickFixRemoveExceptionDocumentation; }
    }

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        var docCommentModel = Error.ExceptionDocumentation.AnalyzeUnit.DocumentationBlock;
        docCommentModel.RemoveExceptionDocumentation(Error.ExceptionDocumentation, progress);
        return null;
    }
}
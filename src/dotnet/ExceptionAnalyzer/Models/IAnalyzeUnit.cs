using JetBrains.ReSharper.Psi.Modules;
using JetBrains.ReSharper.Psi.Tree;
using ExceptionAnalyzer.Analyzers;

namespace ExceptionAnalyzer.Models;

internal interface IAnalyzeUnit : IBlockModel
{
    ITreeNode Node { get; }

    IPsiModule GetPsiModule();

    DocCommentBlockModel DocumentationBlock { get; set; }

    bool IsInspectionRequired { get; }

    void Accept(AnalyzerBase analyzer);
}
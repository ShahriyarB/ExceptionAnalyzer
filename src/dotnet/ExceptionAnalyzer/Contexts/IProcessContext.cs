using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

using ExceptionAnalyzer.Models;

namespace ExceptionAnalyzer.Contexts;

internal interface IProcessContext
{
    IAnalyzeUnit Model { get; }

    void StartProcess(IAnalyzeUnit analyzeUnit);
    void RunAnalyzers();

    void EnterTryBlock(ITryStatement tryStatement);
    void LeaveTryBlock();

    void EnterCatchClause(ICatchClause catchClauseNode);
    void LeaveCatchClause();

    void Process(IThrowStatement throwStatement);
    void Process(ICatchVariableDeclaration catchVariableDeclaration);
    void Process(IReferenceExpression invocationExpression);
    void Process(IObjectCreationExpression objectCreationExpression);
    void Process(IDocCommentBlock docCommentBlockNode);
    void Process(IThrowExpression throwExpression);
    void EnterAccessor(IAccessorDeclaration accessorDeclarationNode);
    void LeaveAccessor();
}
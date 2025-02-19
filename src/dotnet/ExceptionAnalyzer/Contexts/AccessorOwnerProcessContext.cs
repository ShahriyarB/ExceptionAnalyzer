using JetBrains.ReSharper.Psi.CSharp.Tree;

using ExceptionAnalyzer.Models;

namespace ExceptionAnalyzer.Contexts;

internal class AccessorOwnerProcessContext : ProcessContext<AccessorOwnerDeclarationModel>
{
    public override void EnterAccessor(IAccessorDeclaration accessorDeclarationNode)
    {
            if (IsValid() == false)
                return;

            if (accessorDeclarationNode == null)
                return;

            var accessor = new AccessorDeclarationModel(AnalyzeUnit, accessorDeclarationNode, BlockModelsStack.Peek());
            Model.Accessors.Add(accessor);

            BlockModelsStack.Push(accessor);
        }

    public override void LeaveAccessor()
    {
            BlockModelsStack.Pop();
        }
}
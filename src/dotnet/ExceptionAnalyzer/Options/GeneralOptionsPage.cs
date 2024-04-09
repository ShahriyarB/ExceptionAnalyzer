using JetBrains.Application.Settings;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.DataFlow;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using ExceptionAnalyzer.Settings;

namespace ExceptionAnalyzer.Options;

[OptionsPage(Pid, Name, typeof(UnnamedThemedIcons.ExceptionAnalyzerSettings), ParentId = ExceptionAnalyzerOptionsPage.Pid, Sequence = 0.0)]
public class GeneralOptionsPage : BeSimpleOptionsPage
{
    public const string Pid = "ExceptionAnalyzer::General";
    public const string Name = "General";

    public GeneralOptionsPage(Lifetime lifetime, OptionsPageContext optionsPageContext, OptionsSettingsSmartContext optionsSettingsSmartContext, bool wrapInScrollablePanel = false) : base(lifetime, optionsPageContext, optionsSettingsSmartContext, wrapInScrollablePanel)
    {
            CreateCheckboxInspectPublic(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);

            CreateDocumentationSection(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
        }

    private void CreateCheckboxInspectPublic(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::General::DelegateInvocationsMayThrowSystemException");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.DelegateInvocationsMayThrowExceptions));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;
                
                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.DelegateInvocationsMayThrowExceptions, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.DelegateInvocationsMayThrowExceptions, OptionsLabels.General.DelegateInvocationsMayThrowSystemException);
        }

    private void CreateDocumentationSection(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            AddHeader(OptionsLabels.General.DocumentationOfThrownExceptionsSubtypeHeader);

            CreateCheckboxIsDocumentationOfExceptionSubtypeSufficientForThrowStatements(lifetime, storeOptionsTransactionContext);
            CreateCheckboxIsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions(lifetime, storeOptionsTransactionContext);
        }

    private void CreateCheckboxIsDocumentationOfExceptionSubtypeSufficientForThrowStatements(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::General::IsDocumentationOfExceptionSubtypeSufficientForThrowStatements");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForThrowStatements));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;
                
                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForThrowStatements, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForThrowStatements, OptionsLabels.General.IsDocumentationOfExceptionSubtypeSufficientForThrowStatements);
        }

    private void CreateCheckboxIsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::General::IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;
                
                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions, OptionsLabels.General.IsDocumentationOfExceptionSubtypeSufficientForReferenceExpressions);
        }
}
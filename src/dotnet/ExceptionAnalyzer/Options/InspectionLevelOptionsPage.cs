using JetBrains.Application.Settings;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.DataFlow;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using ExceptionAnalyzer.Settings;

namespace ExceptionAnalyzer.Options;

[OptionsPage(Pid, Name, typeof(UnnamedThemedIcons.ExceptionAnalyzerSettings), ParentId = ExceptionAnalyzerOptionsPage.Pid, Sequence = 1.0)]
public class InspectionLevelOptionsPage : BeSimpleOptionsPage
{
    public const string Pid = "ExceptionAnalyzer::InspectionLevel";
    public const string Name = "Inspection Level";

    public InspectionLevelOptionsPage(Lifetime lifetime, OptionsPageContext optionsPageContext, OptionsSettingsSmartContext optionsSettingsSmartContext, bool wrapInScrollablePanel = false) : base(lifetime, optionsPageContext, optionsSettingsSmartContext, wrapInScrollablePanel)
    {
            CreateCheckboxInspectPublic(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
            CreateCheckboxInspectInternal(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
            CreateCheckboxInspectProtected(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
            CreateCheckboxInspectPrivate(lifetime, optionsSettingsSmartContext.StoreOptionsTransactionContext);
        }

    private void CreateCheckboxInspectPublic(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::InspectionLevel::InspectPublicMethodsAndProperties");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.InspectPublicMethods));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;
                
                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.InspectPublicMethods, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.InspectPublicMethods, OptionsLabels.InspectionLevel.InspectPublicMethodsAndProperties);
        }

    private void CreateCheckboxInspectInternal(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::InspectionLevel::InspectInternalMethodsAndProperties");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.InspectInternalMethods));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;

                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.InspectInternalMethods, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.InspectInternalMethods, OptionsLabels.InspectionLevel.InspectInternalMethodsAndProperties);
        }

    private void CreateCheckboxInspectProtected(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::InspectionLevel::InspectProtectedMethodsAndProperties");
            property.SetValue(storeOptionsTransactionContext.GetValue(
                (ExceptionAnalyzerSettings key) => key.InspectProtectedMethods));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;

                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.InspectProtectedMethods, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.InspectProtectedMethods, OptionsLabels.InspectionLevel.InspectProtectedMethodsAndProperties);
        }

    private void CreateCheckboxInspectPrivate(Lifetime lifetime, IContextBoundSettingsStoreLive storeOptionsTransactionContext)
    {
            IProperty<bool> property = new Property<bool>(lifetime, "ExceptionAnalyzer::InspectionLevel::InspectPrivateMethodsAndProperties");
            property.SetValue(storeOptionsTransactionContext.GetValue((ExceptionAnalyzerSettings key) => key.InspectPrivateMethods));

            property.Change.Advise(lifetime, a =>
            {
                if (!a.HasNew) return;

                storeOptionsTransactionContext.SetValue((ExceptionAnalyzerSettings key) => key.InspectPrivateMethods, a.New);
            });

            AddBoolOption((ExceptionAnalyzerSettings key) => key.InspectPrivateMethods, OptionsLabels.InspectionLevel.InspectPrivateMethodsAndProperties);
        }
}
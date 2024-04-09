using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionsDialog;

namespace ExceptionAnalyzer.Options;

[OptionsPage(Pid, Name, null, Sequence = 5.0)]
public class ExceptionAnalyzerOptionsPage : AEmptyOptionsPage
{
    public const string Pid = "ExceptionAnalyzer";
    public const string Name = "ExceptionAnalyzer";
}
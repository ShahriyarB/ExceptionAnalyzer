using JetBrains.ReSharper.Psi;

namespace ExceptionAnalyzer.Settings;

public class OptionalExceptionConfiguration
{
    public OptionalExceptionConfiguration(IDeclaredType exceptionType, OptionalExceptionReplacementType replacementType)
    {
            ExceptionType = exceptionType;
            ReplacementType = replacementType;
        }

    public IDeclaredType ExceptionType { get; private set; }

    public OptionalExceptionReplacementType ReplacementType { get; private set; }
}
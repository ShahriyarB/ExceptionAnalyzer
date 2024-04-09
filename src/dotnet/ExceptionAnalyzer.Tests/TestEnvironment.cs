using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;
[assembly: Apartment(ApartmentState.STA)]

namespace ExceptionAnalyzer.Tests;

[ZoneDefinition]
public class ExceptionAnalyzerTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<IExceptionAnalyzerZone> { }

[ZoneMarker]
public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<ExceptionAnalyzerTestEnvironmentZone> { }

[SetUpFixture]
public class ExceptionAnalyzerTestsAssembly : ExtensionTestEnvironmentAssembly<ExceptionAnalyzerTestEnvironmentZone> { }
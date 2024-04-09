namespace ExceptionAnalyzer
{
  using System;
  using JetBrains.Application.I18n;
  using JetBrains.DataFlow;
  using JetBrains.Diagnostics;
  using JetBrains.Lifetimes;
  using JetBrains.Util;
  using JetBrains.Util.Logging;
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public static class AnalyzerResources
  {
    private static readonly ILogger ourLog = Logger.GetLogger("ExceptionAnalyzer.AnalyzerResources");

    static AnalyzerResources()
    {
      CultureContextComponent.Instance.WhenNotNull(Lifetime.Eternal, (lifetime, instance) =>
      {
        lifetime.Bracket(() =>
          {
            ourResourceManager = new Lazy<JetResourceManager>(
              () =>
              {
                return instance
                  .CreateResourceManager("ExceptionAnalyzer.AnalyzerResources", typeof(AnalyzerResources).Assembly);
              });
          },
          () =>
          {
            ourResourceManager = null;
          });
      });
    }
    
    private static Lazy<JetResourceManager> ourResourceManager = null;
    
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    public static JetResourceManager ResourceManager
    {
      get
      {
        var resourceManager = ourResourceManager;
        if (resourceManager == null)
        {
          return ErrorJetResourceManager.Instance;
        }
        return resourceManager.Value;
      }
    }

    public static string HighlightCatchAllClauses => ResourceManager.GetString("HighlightCatchAllClauses");
    public static string HighlightEventNotDocumentedExceptions => ResourceManager.GetString("HighlightEventNotDocumentedExceptions");
    public static string HighlightNotDocumentedExceptions => ResourceManager.GetString("HighlightNotDocumentedExceptions");
    public static string HighlightNotThrownDocumentedExceptions => ResourceManager.GetString("HighlightNotThrownDocumentedExceptions");
    public static string HighlightSwallowingExceptions => ResourceManager.GetString("HighlightSwallowingExceptions");
    public static string HighlightThrowingFromCatchWithoutInnerException => ResourceManager.GetString("HighlightThrowingFromCatchWithoutInnerException");
    public static string HighlightThrowingSystemException => ResourceManager.GetString("HighlightThrowingSystemException");
    public static string QuickFixCatchException => ResourceManager.GetString("QuickFixCatchException");
    public static string QuickFixIncludeInnerException => ResourceManager.GetString("QuickFixIncludeInnerException");
    public static string QuickFixInsertExceptionDocumentation => ResourceManager.GetString("QuickFixInsertExceptionDocumentation");
    public static string QuickFixRemoveExceptionDocumentation => ResourceManager.GetString("QuickFixRemoveExceptionDocumentation");
  }
}
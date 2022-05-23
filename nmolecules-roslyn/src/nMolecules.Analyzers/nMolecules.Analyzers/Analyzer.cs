using System;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers
{
    public abstract class Analyzer<TAttribute> : DiagnosticAnalyzer where TAttribute : Attribute
    {
        public sealed override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                                   GeneratedCodeAnalysisFlags.ReportDiagnostics);
            Initialize(new AnalysisContext<TAttribute>(context));
            context.EnableConcurrentExecution();
        }

        protected abstract void Initialize(AnalysisContext<TAttribute> context);
    }
}
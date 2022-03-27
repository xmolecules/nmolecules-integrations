using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using NMolecules.Analyzers.Common;
using NMolecules.DDD;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public class RepositoryAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Rules.RepositoriesMustNotUseServicesRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                                   GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            var fieldAnalyzer = new FieldAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionFor<RepositoryAttribute>(fieldAnalyzer.AnalyzeField, SymbolKind.Field);
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeInSymbol);
            context.RegisterSymbolActionFor<RepositoryAttribute>(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            var propertyAnalyzer = new PropertyAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionFor<RepositoryAttribute>(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
        }
    }
}
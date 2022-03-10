using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using NMolecules.Analyzers.Common;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AggregateRootAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Rules.AggregateRootsMustNotUseRepositoriesRule, Rules.AggregateRootsMustNotUseServicesRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                                   GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            var fieldAnalyzer = new FieldAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionForAggregateRoot(fieldAnalyzer.AnalyzeField, SymbolKind.Field);
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeInSymbol);
            context.RegisterSymbolActionForAggregateRoot(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            var propertyAnalyzer = new PropertyAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionForAggregateRoot(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
            context.RegisterSyntaxNodeActionForAggregateRoot(methodAnalyzer.AnalyzeDeclarations, SyntaxKind.LocalDeclarationStatement);
        }
    }
}
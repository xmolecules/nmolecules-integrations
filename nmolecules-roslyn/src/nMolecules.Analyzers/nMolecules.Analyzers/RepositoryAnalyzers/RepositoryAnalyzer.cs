using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NMolecules.DDD;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    [Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RepositoryAnalyzer : Analyzer<RepositoryAttribute>
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Rules.RepositoriesShouldNotUseServicesRule);

        protected override void Initialize(AnalysisContext<RepositoryAttribute> context)
        {
            var fieldAnalyzer = new FieldAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeInSymbol);
            var propertyAnalyzer = new PropertyAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolAction(fieldAnalyzer.AnalyzeField, SymbolKind.Field);
            context.RegisterSymbolAction(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            context.RegisterSymbolAction(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
            context.RegisterSyntaxNodeAction(methodAnalyzer.AnalyzeDeclarations, SyntaxKind.LocalDeclarationStatement);
        }
    }
}
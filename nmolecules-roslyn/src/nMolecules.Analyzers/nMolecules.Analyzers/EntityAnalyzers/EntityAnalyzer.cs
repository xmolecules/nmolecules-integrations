using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using NMolecules.Analyzers.Common;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class EntityAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Rules.EntitiesMustNotUseRepositoriesRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                                   GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            var fieldAnalyzer = new FieldAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionForEntity(fieldAnalyzer.AnalyzeField, SymbolKind.Field);
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeInSymbol);
            context.RegisterSymbolActionForEntity(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            var propertyAnalyzer = new PropertyAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolActionForEntity(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
            context.RegisterSyntaxNodeActionForEntity(methodAnalyzer.AnalyzeDeclarations, SyntaxKind.LocalDeclarationStatement);
        }
    }
}
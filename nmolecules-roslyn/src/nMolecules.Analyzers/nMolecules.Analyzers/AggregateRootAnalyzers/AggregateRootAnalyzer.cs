using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using NMolecules.DDD;
using static NMolecules.Analyzers.IdAnalyzer;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AggregateRootAnalyzer : Analyzer<AggregateRootAttribute>
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            Rules.AggregateRootsShouldNotUseRepositoriesRule,
            Rules.AggregateRootsShouldNotUseServicesRule,
            Rules.AggregateRootsShouldHaveIdRule);

        protected override void Initialize(AnalysisContext<AggregateRootAttribute> context)
        {
            var fieldAnalyzer = new FieldAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeInSymbol);
            var propertyAnalyzer = new PropertyAnalyzer(it => Diagnostics.AnalyzeTypeInSymbol(it, it.Type));
            context.RegisterSymbolAction(fieldAnalyzer.AnalyzeField, SymbolKind.Field);
            context.RegisterSymbolAction(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            context.RegisterSymbolAction(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
            context.RegisterSymbolAction(it => AnalyzeEntityForId(it, typeSymbol => typeSymbol.ViolatesMandatoryId()), SymbolKind.NamedType);
            context.RegisterSyntaxNodeAction(methodAnalyzer.AnalyzeDeclarations, SyntaxKind.LocalDeclarationStatement);
        }
    }
}
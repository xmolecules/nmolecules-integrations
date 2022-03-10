using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using NMolecules.Analyzers.Common;
using static NMolecules.Analyzers.ValueObjectAnalyzers.Rules;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ValueObjectAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
            => ImmutableArray.Create(ValueObjectMustNotUseEntityRule,
                ValueObjectMustNotUseServiceRule,
                ValueObjectMustNotUseRepositoryRule,
                ValueObjectMustNotUseAggregateRootRule,
                ValueObjectMustBeImmutableRule,
                ValueObjectMustImplementIEquatableRule,
                ValueObjectMustBeSealedRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                                   GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            var methodAnalyzer = new MethodAnalyzer(Diagnostics.AnalyzeTypeUsageInSymbol);
            context.RegisterSymbolActionForValueObject(methodAnalyzer.AnalyzeMethod, SymbolKind.Method);
            var propertyAnalyzer = new ValueObjectPropertyAnalyzer();
            context.RegisterSymbolActionForValueObject(propertyAnalyzer.AnalyzeProperty, SymbolKind.Property);
            context.RegisterSymbolActionForValueObject(ClassSymbolAnalyzer.AnalyzeType, SymbolKind.NamedType);
            var valueObjectFieldAnalyzer = new ValueObjectFieldAnalyzer();
            context.RegisterSymbolActionForValueObject(valueObjectFieldAnalyzer.AnalyzeField, SymbolKind.Field);
            context.RegisterSyntaxNodeActionForValueObject(methodAnalyzer.AnalyzeDeclarations, SyntaxKind.LocalDeclarationStatement);
        }
    }
}
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSymbolActionForValueObject(
            this AnalysisContext analysisContext,
            Action<SymbolAnalysisContext> action,
            SymbolKind symbolKind)
        {
            analysisContext.RegisterSymbolAction(IfValueObject(action, symbolKind), symbolKind);
        }

        private static Action<SymbolAnalysisContext> IfValueObject(
            Action<SymbolAnalysisContext> analyze,
            SymbolKind symbolKind)
        {
            return symbolKind switch
            {
                SymbolKind.NamedType => it =>
                {
                    var classType = (INamedTypeSymbol)it.Symbol;
                    if (classType.IsValueObject())
                    {
                        analyze(it);
                    }
                },
                _ => it =>
                {
                    var classType = it.Symbol.ContainingType;
                    if (classType.IsValueObject())
                    {
                        analyze(it);
                    }
                }
            };
        }

        public static void RegisterSyntaxNodeActionForValueObject(
            this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis,
            SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfValueObject(analysis), syntaxKind);
        }

        private static Action<SyntaxNodeAnalysisContext> IfValueObject(Action<SyntaxNodeAnalysisContext> analyze)
        {
            return it =>
            {
                if (it.ContainingSymbol is { ContainingSymbol: ITypeSymbol typeSymbol } &&
                    typeSymbol.IsValueObject())
                {
                    analyze(it);
                }
            };
        }
    }
}
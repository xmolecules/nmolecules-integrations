using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSymbolActionForAggregateRoot(
            this AnalysisContext analysisContext,
            Action<SymbolAnalysisContext> action,
            SymbolKind symbolKind)
        {
            analysisContext.RegisterSymbolAction(IfAggregateRoot(action, symbolKind), symbolKind);
        }

        public static void RegisterSyntaxNodeActionForAggregateRoot(
            this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis,
            SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfAggregateRoot(analysis), syntaxKind);
        }

        private static Action<SymbolAnalysisContext> IfAggregateRoot(
            Action<SymbolAnalysisContext> analyze,
            SymbolKind symbolKind)
        {
            return symbolKind switch
            {
                SymbolKind.NamedType => it =>
                {
                    var classType = (INamedTypeSymbol)it.Symbol;
                    if (classType.IsAggregateRoot())
                    {
                        analyze(it);
                    }
                },
                _ => it =>
                {
                    var classType = it.Symbol.ContainingType;
                    if (classType.IsAggregateRoot())
                    {
                        analyze(it);
                    }
                }
            };
        }

        private static Action<SyntaxNodeAnalysisContext> IfAggregateRoot(Action<SyntaxNodeAnalysisContext> analyze)
        {
            return it =>
            {
                if (it.ContainingSymbol is { ContainingSymbol: ITypeSymbol typeSymbol } && typeSymbol.IsAggregateRoot())
                {
                    analyze(it);
                }
            };
        }
    }
}
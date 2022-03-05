using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSymbolActionForEntity(this AnalysisContext analysisContext,
            Action<SymbolAnalysisContext> action, SymbolKind symbolKind)
        {
            analysisContext.RegisterSymbolAction(IfEntity(action, symbolKind), symbolKind);
        }

        private static Action<SymbolAnalysisContext> IfEntity(Action<SymbolAnalysisContext> analyze,
            SymbolKind symbolKind)
        {
            return symbolKind switch
            {
                SymbolKind.NamedType => it =>
                {
                    var classType = (INamedTypeSymbol) it.Symbol;
                    if (classType.IsEntity()) analyze(it);
                },
                _ => it =>
                {
                    var classType = it.Symbol.ContainingType;
                    if (classType.IsEntity()) analyze(it);
                }
            };
        }

        public static void RegisterSyntaxNodeActionForEntity(this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis, SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfEntity(analysis), syntaxKind);
        }

        private static Action<SyntaxNodeAnalysisContext> IfEntity(Action<SyntaxNodeAnalysisContext> analyze)
        {
            return it =>
            {
                if (it.ContainingSymbol is {ContainingSymbol: ITypeSymbol typeSymbol} &&
                    typeSymbol.IsEntity()) analyze(it);
            };
        }
    }
}
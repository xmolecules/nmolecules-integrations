using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSyntaxNodeActionForAggregateRoot(
            this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis,
            SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfAggregateRoot(analysis), syntaxKind);
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
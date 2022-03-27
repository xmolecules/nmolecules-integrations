using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSyntaxNodeActionForEntity(
            this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis,
            SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfEntity(analysis), syntaxKind);
        }

        private static Action<SyntaxNodeAnalysisContext> IfEntity(Action<SyntaxNodeAnalysisContext> analyze)
        {
            return it =>
            {
                if (it.ContainingSymbol is { ContainingSymbol: ITypeSymbol typeSymbol } &&
                    typeSymbol.IsEntity())
                {
                    analyze(it);
                }
            };
        }
    }
}
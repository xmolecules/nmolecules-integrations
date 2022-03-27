using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public static class AnalysisContextExtensions
    {
        public static void RegisterSyntaxNodeActionForRepository(
            this AnalysisContext analysisContext,
            Action<SyntaxNodeAnalysisContext> analysis,
            SyntaxKind syntaxKind)
        {
            analysisContext.RegisterSyntaxNodeAction(IfRepository(analysis), syntaxKind);
        }

        private static Action<SyntaxNodeAnalysisContext> IfRepository(Action<SyntaxNodeAnalysisContext> analyze)
        {
            return it =>
            {
                if (it.ContainingSymbol is { ContainingSymbol: ITypeSymbol typeSymbol } &&
                    typeSymbol.IsRepository())
                {
                    analyze(it);
                }
            };
        }
    }
}
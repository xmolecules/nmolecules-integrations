using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class AnalysisContextExtensions
    {
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
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers
{
    public static class ContextExtensions
    {
        public static void ReportDiagnostics(this SymbolAnalysisContext context, IEnumerable<Diagnostic> violations)
        {
            foreach (var violation in violations)
            {
                context.ReportDiagnostic(violation);
            }
        }

        public static void ReportDiagnostics(this SyntaxNodeAnalysisContext context, IEnumerable<Diagnostic> violations)
        {
            foreach (var violation in violations)
            {
                context.ReportDiagnostic(violation);
            }
        }

        public static void RegisterSymbolActionFor<TAttribute>(
            this AnalysisContext analysisContext,
            Action<SymbolAnalysisContext> action,
            SymbolKind symbolKind) where TAttribute : Attribute
        {
            analysisContext.RegisterSymbolAction(IfCorrectType<TAttribute>(action, symbolKind), symbolKind);
        }

        private static Action<SymbolAnalysisContext> IfCorrectType<TAttribute>(
            Action<SymbolAnalysisContext> analyze,
            SymbolKind symbolKind) where TAttribute : Attribute
        {
            return symbolKind switch
            {
                SymbolKind.NamedType => it =>
                {
                    var classType = (INamedTypeSymbol)it.Symbol;
                    if (classType.Is<TAttribute>())
                    {
                        analyze(it);
                    }
                },
                _ => it =>
                {
                    var classType = it.Symbol.ContainingType;
                    if (classType.Is<TAttribute>())
                    {
                        analyze(it);
                    }
                }
            };
        }
    }
}
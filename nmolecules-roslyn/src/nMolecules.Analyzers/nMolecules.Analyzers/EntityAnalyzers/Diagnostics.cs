using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Diagnostics
    {
        public static void EnsureTypeIsAllowed(SymbolAnalysisContext context, ISymbol symbol, ITypeSymbol type)
        {
            EnsureTypeIsAllowed(context.ReportDiagnostic, symbol, type);
        }

        public static void EnsureTypeIsAllowed(SyntaxNodeAnalysisContext context, ISymbol symbol, ITypeSymbol type)
        {
            EnsureTypeIsAllowed(context.ReportDiagnostic, symbol, type);
        }

        private static void EnsureTypeIsAllowed(Action<Diagnostic> reportDiagnostic, ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsRepository())
                reportDiagnostic(symbol.ViolatesRepositoryUsage());
        }
        private static Diagnostic ViolatesRepositoryUsage(this ISymbol symbol)
        {
            return symbol.Diagnostic(Rules.EntitiesMustNotUseRepositoriesRule);
        }
    }
}
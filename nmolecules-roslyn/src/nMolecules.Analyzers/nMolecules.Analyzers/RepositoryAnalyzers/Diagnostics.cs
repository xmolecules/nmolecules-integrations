using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.RepositoryAnalyzers
{
    public static class Diagnostics
    {
        public static IEnumerable<Diagnostic> AnalyzeTypeInSymbol(ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsService())
            {
                yield return symbol.ViolatesServiceUsage();
            }
        }

        private static Diagnostic ViolatesServiceUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.RepositoriesMustNotUseServicesRule);
    }
}

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.AggregateRootAnalyzers
{
    public static class Diagnostics
    {
        public static IEnumerable<Diagnostic> AnalyzeTypeInSymbol(ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsRepository())
            {
                yield return symbol.ViolatesRepositoryUsage();
            }
            
            if (type.IsService())
            {
                yield return symbol.ViolatesServiceUsage();
            }
        }

        private static Diagnostic ViolatesRepositoryUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.AggregateRootsShouldNotUseRepositoriesRule);
        private static Diagnostic ViolatesServiceUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.AggregateRootsShouldNotUseServicesRule);
        public static Diagnostic ViolatesMandatoryId(this ISymbol symbol) => symbol.Diagnostic(Rules.AggregateRootsShouldHaveIdRule);
    }
}
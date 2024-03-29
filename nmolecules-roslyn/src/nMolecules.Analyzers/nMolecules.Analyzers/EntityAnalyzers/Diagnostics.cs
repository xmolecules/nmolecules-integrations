﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class Diagnostics
    {
        public static IEnumerable<Diagnostic> AnalyzeTypeInSymbol(ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsRepository())
            {
                yield return symbol.ViolatesRepositoryUsage();
            }

            if (type.IsAggregateRoot())
            {
                yield return symbol.ViolatesAggregateRootUsage();
            }
            
            if (type.IsService())
            {
                yield return symbol.ViolatesServiceUsage();
            }
        }

        private static Diagnostic ViolatesRepositoryUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.EntitiesShouldNotUseRepositoriesRule);
        private static Diagnostic ViolatesAggregateRootUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.EntitiesShouldNotUseAggregateRootsRule);
        private static Diagnostic ViolatesServiceUsage(this ISymbol symbol) => symbol.Diagnostic(Rules.EntitiesShouldNotUseServicesRule);
        public static Diagnostic ViolatesMandatoryId(this ISymbol symbol) => symbol.Diagnostic(Rules.EntitiesShouldHaveIdRule);
    }
}
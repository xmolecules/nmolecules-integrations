using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.ValueObjectAnalyzers.Rules;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class Diagnostics
    {
        public static Diagnostic ViolatesImmutability(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustBeImmutableRule);

        public static Diagnostic DoesNotImplementIEquatable(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustImplementIEquatableRule);

        public static Diagnostic IsNotSealed(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustBeSealedRule);

        public static void EnsureTypeIsAllowedInSymbol(SymbolAnalysisContext context, ISymbol symbol, ITypeSymbol type)
        {
            EnsureTypeIsAllowed(context.ReportDiagnostic, symbol, type);
        }

        public static void EnsureTypeIsAllowedInLocalSymbol(SyntaxNodeAnalysisContext context, ISymbol symbol, ITypeSymbol type)
        {
            EnsureTypeIsAllowed(context.ReportDiagnostic, symbol, type);
        }

        private static void EnsureTypeIsAllowed(Action<Diagnostic> reportDiagnostic, ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsEntity())
            {
                reportDiagnostic(symbol.ViolatesEntityUsage());
            }

            if (type.IsService())
            {
                reportDiagnostic(symbol.ViolatesServiceUsage());
            }

            if (type.IsRepository())
            {
                reportDiagnostic(symbol.ViolatesRepositoryUsage());
            }

            if (type.IsAggregateRoot())
            {
                reportDiagnostic(symbol.ViolatesAggregateRootUsage());
            }
        }

        public static IEnumerable<Diagnostic> AnalyzeTypeUsageInSymbol(ISymbol symbol, ITypeSymbol type)
        {
            if (type.IsEntity())
            {
                yield return symbol.ViolatesEntityUsage();
            }

            if (type.IsService())
            {
                yield return symbol.ViolatesServiceUsage();
            }

            if (type.IsRepository())
            {
                yield return symbol.ViolatesRepositoryUsage();
            }

            if (type.IsAggregateRoot())
            {
                yield return symbol.ViolatesAggregateRootUsage();
            }
        }

        private static Diagnostic ViolatesEntityUsage(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustNotUseEntityRule);

        private static Diagnostic ViolatesServiceUsage(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustNotUseServiceRule);

        private static Diagnostic ViolatesRepositoryUsage(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustNotUseRepositoryRule);

        private static Diagnostic ViolatesAggregateRootUsage(this ISymbol symbol) => symbol.Diagnostic(ValueObjectMustNotUseAggregateRootRule);
    }
}
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class ClassSymbolAnalyzer
    {
        public static void AnalyzeType(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol) context.Symbol;
            EnsureValueObjectIsSealed(context, namedTypeSymbol);
            EnsureValueObjectImplementsIEquatable(context, namedTypeSymbol);
        }

        private static void EnsureValueObjectIsSealed(SymbolAnalysisContext context, INamedTypeSymbol namedTypeSymbol)
        {
            if (!namedTypeSymbol.IsSealed) context.ReportDiagnostic(namedTypeSymbol.IsNotSealed());
        }

        private static void EnsureValueObjectImplementsIEquatable(SymbolAnalysisContext context,
            INamedTypeSymbol namedTypeSymbol)
        {
            var implementsIEquatable = namedTypeSymbol.AllInterfaces.Any(it =>
            {
                var implements = it.Name.Equals("IEquatable");
                implements &= it.TypeArguments.Any(tp =>
                    tp.Name.Equals(namedTypeSymbol.Name) &&
                    SymbolEqualityComparer.Default.Equals(tp.ContainingNamespace, namedTypeSymbol.ContainingNamespace));
                return implements;
            });

            if (!implementsIEquatable) context.ReportDiagnostic(namedTypeSymbol.DoesNotImplementIEquatable());
        }
    }
}
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.ValueObjectAnalyzers.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class PropertyAnalyzer
    {
        public static void AnalyzeProperty(SymbolAnalysisContext context)
        {
            var propertySymbol = (IPropertySymbol) context.Symbol;
            EnsureThatPropertyIsReadonly(context, propertySymbol);
            EnsureThatPropertyIsNotOfAnEntityType(context, propertySymbol);
        }

        private static void EnsureThatPropertyIsNotOfAnEntityType(SymbolAnalysisContext context,
            IPropertySymbol propertySymbol)
        {
            EnsureTypeIsAllowed(context, propertySymbol, propertySymbol.Type);
        }

        private static void EnsureThatPropertyIsReadonly(SymbolAnalysisContext context, IPropertySymbol propertySymbol)
        {
            if (!propertySymbol.IsReadOnly) context.ReportDiagnostic(propertySymbol.ViolatesImmutability());
        }
    }
}
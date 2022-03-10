using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.EntityAnalyzers.Diagnostics;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public class PropertyAnalyzer
    {
        public static void AnalyzeProperty(SymbolAnalysisContext context)
        {
            var propertySymbol = (IPropertySymbol)context.Symbol;
            EnsureThatPropertyIsNotOfAnEntityType(context, propertySymbol);
        }

        private static void EnsureThatPropertyIsNotOfAnEntityType(SymbolAnalysisContext context, IPropertySymbol propertySymbol)
        {
            var violations = AnalyzeTypeInSymbol(propertySymbol, propertySymbol.Type);
            context.ReportDiagnostics(violations);
        }
    }
}
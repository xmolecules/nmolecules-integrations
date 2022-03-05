using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.EntityAnalyzers.Diagnostics;

namespace NMolecules.Analyzers.EntityAnalyzers
{
    public static class FieldAnalyzer
    {
        public static void AnalyzeField(SymbolAnalysisContext context)
        {
            var fieldSymbol = (IFieldSymbol)context.Symbol;
            EnsureFieldIsNoEntity(context, fieldSymbol);
        }

        private static void EnsureFieldIsNoEntity(SymbolAnalysisContext context, IFieldSymbol fieldSymbol)
        {
            EnsureTypeIsAllowed(context, fieldSymbol, fieldSymbol.Type);
        }
    }
}
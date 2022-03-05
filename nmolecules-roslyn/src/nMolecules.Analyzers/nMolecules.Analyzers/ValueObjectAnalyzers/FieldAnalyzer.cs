using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NMolecules.Analyzers.ValueObjectAnalyzers.Diagnostics;

namespace NMolecules.Analyzers.ValueObjectAnalyzers
{
    public static class FieldAnalyzer
    {
        public static void AnalyzeField(SymbolAnalysisContext context)
        {
            var fieldSymbol = (IFieldSymbol)context.Symbol;
            EnsureFieldIsReadonly(context, fieldSymbol);
            EnsureFieldIsNoEntity(context, fieldSymbol);
        }

        private static void EnsureFieldIsNoEntity(SymbolAnalysisContext context, IFieldSymbol fieldSymbol)
        {
            EnsureTypeIsAllowed(context, fieldSymbol, fieldSymbol.Type);
        }

        private static void EnsureFieldIsReadonly(SymbolAnalysisContext context, IFieldSymbol fieldSymbol)
        {
            if (!(fieldSymbol.IsReadOnly || fieldSymbol.IsConst))
            {
                context.ReportDiagnostic(fieldSymbol.ViolatesImmutability());
            }
        }
    }
}
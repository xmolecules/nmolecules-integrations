using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers.Common
{
    public class FieldAnalyzer
    {
        private readonly Func<IFieldSymbol, ITypeSymbol, IEnumerable<Diagnostic>> analyzeTypeUsageInSymbol;

        public FieldAnalyzer(Func<IFieldSymbol, ITypeSymbol, IEnumerable<Diagnostic>> analyzeTypeUsageInSymbol)
        {
            this.analyzeTypeUsageInSymbol = analyzeTypeUsageInSymbol;
        }
        
        public void AnalyzeField(SymbolAnalysisContext context)
        {
            var fieldSymbol = (IFieldSymbol)context.Symbol;
            var violations = analyzeTypeUsageInSymbol(fieldSymbol, fieldSymbol.Type);
            context.ReportDiagnostics(violations);
        }
    }
}
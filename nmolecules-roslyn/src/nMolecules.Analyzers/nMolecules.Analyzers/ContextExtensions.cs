using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers
{
    public static class ContextExtensions
    {
        public static void ReportDiagnostics(this SymbolAnalysisContext context, IEnumerable<Diagnostic> violations)
        {
            foreach (var violation in violations)
            {
                context.ReportDiagnostic(violation);
            }
        }
        
        public static void ReportDiagnostics(this SyntaxNodeAnalysisContext context, IEnumerable<Diagnostic> violations)
        {
            foreach (var violation in violations)
            {
                context.ReportDiagnostic(violation);
            }
        }
    }
}
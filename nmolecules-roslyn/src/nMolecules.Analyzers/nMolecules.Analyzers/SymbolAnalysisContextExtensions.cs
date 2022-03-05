using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace NMolecules.Analyzers
{
    public static class SymbolAnalysisContextExtensions
    {
        public static void EmitViolation(this SymbolAnalysisContext context, ISymbol symbol,
            DiagnosticDescriptor valueObjectMustBeSealed, params object[] parameters)
        {
            var diagnostic = Diagnostic.Create(valueObjectMustBeSealed, symbol.Locations[0], parameters);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
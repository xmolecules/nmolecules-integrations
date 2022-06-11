using System;
using Microsoft.CodeAnalysis.Testing;

namespace NMolecules.Analyzers.Test
{
    public static class ExpectedResults
    {
        public static DiagnosticResult[] ShouldNotEmitAnyIssues() => Array.Empty<DiagnosticResult>();
        public static DiagnosticResult[] ShouldEmitIssues(params DiagnosticResult[] results) => results;
    }
}
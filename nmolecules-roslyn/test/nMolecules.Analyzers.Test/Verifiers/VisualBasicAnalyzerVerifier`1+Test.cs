using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Microsoft.CodeAnalysis.VisualBasic.Testing;

namespace NMolecules.Analyzers.Test.Verifiers
{
    public static partial class VisualBasicAnalyzerVerifier<TAnalyzer>
        where TAnalyzer : DiagnosticAnalyzer, new()
    {
        public class VisualBasicTest : VisualBasicAnalyzerTest<TAnalyzer, XUnitVerifier>
        {
        }
    }
}
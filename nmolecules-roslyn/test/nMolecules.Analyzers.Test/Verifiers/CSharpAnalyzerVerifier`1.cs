using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;
using Microsoft.CodeAnalysis.Text;

namespace NMolecules.Analyzers.Test.Verifiers
{
    public static partial class CSharpAnalyzerVerifier<TAnalyzer>
        where TAnalyzer : DiagnosticAnalyzer, new()
    {
        private const string AttributesProjectName = "nMolecules.DDD";

        /// <inheritdoc cref="AnalyzerVerifier{TAnalyzer, TTest, TVerifier}.Diagnostic()" />
        public static DiagnosticResult Diagnostic()
        {
            return CSharpAnalyzerVerifier<TAnalyzer, XUnitVerifier>.Diagnostic();
        }

        /// <inheritdoc cref="AnalyzerVerifier{TAnalyzer, TTest, TVerifier}.Diagnostic(string)" />
        public static DiagnosticResult Diagnostic(string diagnosticId)
        {
            return CSharpAnalyzerVerifier<TAnalyzer, XUnitVerifier>.Diagnostic(diagnosticId);
        }

        /// <inheritdoc cref="AnalyzerVerifier{TAnalyzer, TTest, TVerifier}.Diagnostic(DiagnosticDescriptor)" />
        public static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        {
            return CSharpAnalyzerVerifier<TAnalyzer, XUnitVerifier>.Diagnostic(descriptor);
        }

        /// <inheritdoc cref="AnalyzerVerifier{TAnalyzer, TTest, TVerifier}.VerifyAnalyzerAsync(string, DiagnosticResult[])" />
        public static async Task VerifyAnalyzerAsync(string source, params DiagnosticResult[] expected)
        {
            var attributesProject = new ProjectState(AttributesProjectName, LanguageNames.CSharp, string.Empty, "cs");
            attributesProject.ReferenceAssemblies = ReferenceAssemblies.Default;
            attributesProject.ReferenceAssemblies.AddAssemblies(ImmutableArray.Create<string>("nMolecules.DDD.dll"));
            var test = new Test
            {
                TestCode = source,
                TestState =
                {
                    AdditionalProjects = {{AttributesProjectName, attributesProject}},
                    AdditionalProjectReferences = {AttributesProjectName}
                }
            };

            test.ExpectedDiagnostics.AddRange(expected);
            await test.RunAsync(CancellationToken.None);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using NMolecules.Analyzers.RepositoryAnalyzers;
using NMolecules.Analyzers.Test.RepositoryAnalyzerTests.SampleData;
using Xunit;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static NMolecules.Analyzers.Test.ElementNames;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.RepositoryAnalyzers.RepositoryAnalyzer>;

namespace NMolecules.Analyzers.Test.RepositoryAnalyzerTests
{
    public class RepositoryUsesOtherElements
    {
        private const int FieldLineNumber = 14;
        private const int CtorLineNumber = 15;
        private const int PropertyLineNumber = 23;
        private const int MethodLineNumber = 25;
        private const int TypeViolationInMethodBodyLineNumber = 27;

        [Fact]
        public async Task Analyze_ValidRepository_DoesNotEmitCompilerErrors()
        {
            var validRepository = SampleDataLoader.LoadFromNamespaceOf<RepositoryUsesOtherElements>("ValidMaximumRepository.cs");
            await VerifyCS.VerifyAnalyzerAsync(validRepository);
        }

        [Fact]
        public async Task Analyze_WithRepositoryUsesService_EmitsCompilerError()
        {
            var testCode = GenerateClass(Service);
            var serviceAsField = CompilerError(Rules.RepositoriesMustNotUseServicesId)
                .WithSpan(FieldLineNumber, 38, FieldLineNumber, 45);
            var serviceAsParameterInCtor = CompilerError(Rules.RepositoriesMustNotUseServicesId)
                .WithSpan(CtorLineNumber, 46, CtorLineNumber, 51);
            // var serviceAsProperty = CompilerError(Rules.NoRepositoriesInValueObjectsId)
            //     .WithSpan(PropertyLineNumber 1, PropertyLineNumber, 36);
            var serviceAsReturnValue = CompilerError(Rules.RepositoriesMustNotUseServicesId)
                .WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var serviceAsParameterInMethod = CompilerError(Rules.RepositoriesMustNotUseServicesId)
                .WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            // var serviceUsedInMethodBody = CompilerError(Rules.NoRepositoriesInValueObjectsId)
            //     .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 31);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                serviceAsField,
                serviceAsParameterInCtor,
                serviceAsParameterInMethod,
                serviceAsReturnValue);
        }

        private static string GenerateClass(string type)
        {
            var invalidUsageTemplate = new InvalidUsageTemplate
            {
                Session = new Dictionary<string, object> { { "type", type }, { "name", type.ToLowerInvariant() } }
            };
            return invalidUsageTemplate.TransformText();
        }
    }
}
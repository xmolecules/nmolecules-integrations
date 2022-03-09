using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMolecules.Analyzers.EntityAnalyzers;
using NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData;
using Xunit;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static NMolecules.Analyzers.Test.ElementNames;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.EntityAnalyzers.EntityAnalyzer>;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests
{
    public class EntityUsesOtherElements
    {
        private const int FieldLineNumber = 14;
        private const int CtorLineNumber = 15;
        private const int PropertyLineNumber = 20;
        private const int MethodLineNumber = 25;
        private const int EntityInMethodBodyLineNumber = 24;

        [Fact]
        public async Task Analyze_WithEntityUsesRepository_EmitsCompilerError()
        {
            var entity = GenerateClass(Repository);
            var repositoryAsField = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            var repositoryAsParameterInCtor = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(CtorLineNumber, 45, CtorLineNumber, 50);
            var repositoryAsReturnValue = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var repositoryAsParameterInMethod = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            await VerifyCS.VerifyAnalyzerAsync(entity, repositoryAsField, repositoryAsParameterInCtor, repositoryAsParameterInMethod, repositoryAsReturnValue);
        }

        [Fact(Skip = "WiP")]
        public async Task Analyze_WithEntityUsesAggregate_EmitsCompilerError()
        {
            var entity = GenerateClass(AggregateRoot);
            var aggregateAsField = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            await VerifyCS.VerifyAnalyzerAsync(entity, aggregateAsField);
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
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private const int PropertyLineNumber = 23;
        private const int MethodLineNumber = 25;
        private const int TypeViolationInMethodBodyLineNumber = 27;

        [Fact]
        public async Task Analyze_WithEntityUsesRepository_EmitsCompilerError()
        {
            var entity = GenerateClass(Repository);
            var repositoryAsField = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            var repositoryAsParameterInCtor = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(CtorLineNumber, 45, CtorLineNumber, 50);
            var repositoryAsReturnValue = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var repositoryAsParameterInMethod = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            var repositoryAsPropertyType = CompilerError(Rules.EntitiesMustNotUseRepositoriesId).WithSpan(PropertyLineNumber, 31, PropertyLineNumber, 36);
            var repositoryInMethodBody = CompilerError(Rules.EntitiesMustNotUseRepositoriesId)
                .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 31);
            await VerifyCS.VerifyAnalyzerAsync(entity,
                repositoryAsField,
                repositoryAsParameterInCtor,
                repositoryAsParameterInMethod,
                repositoryAsReturnValue,
                repositoryAsPropertyType,
                repositoryInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithEntityUsesAggregate_EmitsCompilerError()
        {
            var entity = GenerateClass(AggregateRoot);
            var aggregateRootAsField = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId).WithSpan(FieldLineNumber, 44, FieldLineNumber, 57);
            var aggregateRootAsParameterInCtor = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId).WithSpan(CtorLineNumber, 48, CtorLineNumber, 53);
            var aggregateRootAsReturnValue = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId).WithSpan(MethodLineNumber, 34, MethodLineNumber, 44);
            var aggregateRootAsParameterInMethod = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId).WithSpan(MethodLineNumber, 63, MethodLineNumber, 76);
            var aggregateRootAsPropertyType = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId).WithSpan(PropertyLineNumber, 34, PropertyLineNumber, 39);
            var aggregateRootInMethodBody = CompilerError(Rules.EntitiesMustNotUseAggregateRootsId)
                .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 34);
            await VerifyCS.VerifyAnalyzerAsync(entity,
                aggregateRootAsField,
                aggregateRootAsParameterInCtor,
                aggregateRootAsParameterInMethod,
                aggregateRootAsReturnValue,
                aggregateRootAsPropertyType,
                aggregateRootInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithEntityUsesService_EmitsCompilerError()
        {
            var entity = GenerateClass(Service);
            var serviceAsField = CompilerError(Rules.EntitiesMustNotUseServicesId).WithSpan(FieldLineNumber, 38, FieldLineNumber, 45);
            var serviceAsParameterInCtor = CompilerError(Rules.EntitiesMustNotUseServicesId).WithSpan(CtorLineNumber, 42, CtorLineNumber, 47);
            var serviceAsReturnValue = CompilerError(Rules.EntitiesMustNotUseServicesId).WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var serviceAsParameterInMethod = CompilerError(Rules.EntitiesMustNotUseServicesId).WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            var serviceAsPropertyType = CompilerError(Rules.EntitiesMustNotUseServicesId).WithSpan(PropertyLineNumber, 28, PropertyLineNumber, 33);
            var serviceInMethodBody = CompilerError(Rules.EntitiesMustNotUseServicesId)
                .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 28);
            await VerifyCS.VerifyAnalyzerAsync(entity,
                serviceAsField,
                serviceAsParameterInCtor,
                serviceAsParameterInMethod,
                serviceAsReturnValue,
                serviceAsPropertyType,
                serviceInMethodBody);
        }
        
        [Fact]
        public async Task Analyze_ValidEntity_DoesNotEmitAnyError()
        {
            var validAggregateRoot = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("ValidMaximumEntity.cs");
            await VerifyCS.VerifyAnalyzerAsync(validAggregateRoot);
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
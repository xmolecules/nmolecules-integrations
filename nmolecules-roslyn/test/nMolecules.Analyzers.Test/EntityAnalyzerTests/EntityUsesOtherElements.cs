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
            var repositoryAsField = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId).WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            var repositoryAsParameterInCtor = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId).WithSpan(CtorLineNumber, 45, CtorLineNumber, 50);
            var repositoryAsReturnValue = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId).WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var repositoryAsParameterInMethod = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId).WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            var repositoryAsPropertyType = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId).WithSpan(PropertyLineNumber, 31, PropertyLineNumber, 36);
            var repositoryInMethodBody = CompilerError(Rules.EntitiesShouldNotUseRepositoriesId)
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
            var aggregateRootAsField = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId).WithSpan(FieldLineNumber, 44, FieldLineNumber, 57);
            var aggregateRootAsParameterInCtor = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId).WithSpan(CtorLineNumber, 48, CtorLineNumber, 53);
            var aggregateRootAsReturnValue = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId).WithSpan(MethodLineNumber, 34, MethodLineNumber, 44);
            var aggregateRootAsParameterInMethod = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId).WithSpan(MethodLineNumber, 63, MethodLineNumber, 76);
            var aggregateRootAsPropertyType = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId).WithSpan(PropertyLineNumber, 34, PropertyLineNumber, 39);
            var aggregateRootInMethodBody = CompilerError(Rules.EntitiesShouldNotUseAggregateRootsId)
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
            var serviceAsField = CompilerError(Rules.EntitiesShouldNotUseServicesId).WithSpan(FieldLineNumber, 38, FieldLineNumber, 45);
            var serviceAsParameterInCtor = CompilerError(Rules.EntitiesShouldNotUseServicesId).WithSpan(CtorLineNumber, 42, CtorLineNumber, 47);
            var serviceAsReturnValue = CompilerError(Rules.EntitiesShouldNotUseServicesId).WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var serviceAsParameterInMethod = CompilerError(Rules.EntitiesShouldNotUseServicesId).WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            var serviceAsPropertyType = CompilerError(Rules.EntitiesShouldNotUseServicesId).WithSpan(PropertyLineNumber, 28, PropertyLineNumber, 33);
            var serviceInMethodBody = CompilerError(Rules.EntitiesShouldNotUseServicesId)
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
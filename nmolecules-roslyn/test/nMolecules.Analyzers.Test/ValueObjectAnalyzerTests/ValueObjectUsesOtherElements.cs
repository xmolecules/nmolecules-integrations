using System.Collections.Generic;
using System.Threading.Tasks;
using NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData;
using NMolecules.Analyzers.ValueObjectAnalyzers;
using Xunit;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<
    NMolecules.Analyzers.ValueObjectAnalyzers.ValueObjectAnalyzer>;
using static NMolecules.Analyzers.Test.ElementNames;

namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests
{
    public class ValueObjectUsesOtherElements
    {
        private const int FieldLineNumber = 14;
        private const int CtorLineNumber = 15;
        private const int PropertyLineNumber = 20;
        private const int MethodLineNumber = 22;
        private const int TypeInMethodBodyLineNumber = 24;

        [Fact]
        public async Task Analyze_WithValueObjectUsesEntity_EmitsCompilerError()
        {
            var testCode = GenerateClass(Entity);
            var entityAsField = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(FieldLineNumber, 37, FieldLineNumber, 43);
            var entityAsParameterInCtor = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(CtorLineNumber, 46, CtorLineNumber, 51);
            var entityAsProperty = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 27, PropertyLineNumber, 32);
            var entityAsReturnValue = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(MethodLineNumber, 27, MethodLineNumber, 37);
            var entityAsParameterInMethod = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(MethodLineNumber, 49, MethodLineNumber, 55);
            var entityUsedInMethodBody = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(TypeInMethodBodyLineNumber, 17, TypeInMethodBodyLineNumber, 27);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                entityAsField,
                entityAsParameterInCtor,
                entityAsProperty,
                entityAsReturnValue,
                entityAsParameterInMethod,
                entityUsedInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithValueObjectUsesService_EmitsCompilerError()
        {
            var testCode = GenerateClass(Service);
            var serviceAsField = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(FieldLineNumber, 38, FieldLineNumber, 45);
            var serviceAsParameterInCtor = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(CtorLineNumber, 47, CtorLineNumber, 52);
            var serviceAsProperty = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 28, PropertyLineNumber, 33);
            var serviceAsReturnValue = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var serviceAsParameterInMethod = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            var serviceUsedInMethodBody = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(TypeInMethodBodyLineNumber, 17, TypeInMethodBodyLineNumber, 28);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                serviceAsField,
                serviceAsParameterInCtor,
                serviceAsProperty,
                serviceAsReturnValue,
                serviceAsParameterInMethod,
                serviceUsedInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithValueObjectUsesRepository_EmitsCompilerError()
        {
            var testCode = GenerateClass(Repository);
            var repositoryAsField = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            var repositoryAsParameterInCtor = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(CtorLineNumber, 50, CtorLineNumber, 55);
            var repositoryAsProperty = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 31, PropertyLineNumber, 36);
            var repositoryAsReturnValue = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var repositoryAsParameterInMethod = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            var repositoryUsedInMethodBody = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(TypeInMethodBodyLineNumber, 17, TypeInMethodBodyLineNumber, 31);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                repositoryAsField,
                repositoryAsParameterInCtor,
                repositoryAsProperty,
                repositoryAsReturnValue,
                repositoryAsParameterInMethod,
                repositoryUsedInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithValueObjectUsesAggregateRoot_EmitsCompilerError()
        {
            var testCode = GenerateClass(AggregateRoot);
            var aggregateRootAsField = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(FieldLineNumber, 44, FieldLineNumber, 57);
            var aggregateRootAsParameterInCtor = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(CtorLineNumber, 53, CtorLineNumber, 58);
            var aggregateRootAsProperty = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(PropertyLineNumber, 34, PropertyLineNumber, 39);
            var aggregateRootAsReturnValue = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(MethodLineNumber, 34, MethodLineNumber, 44);
            var aggregateRootAsParameterInMethod = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(MethodLineNumber, 63, MethodLineNumber, 76);
            var aggregateRootUsedInMethodBody = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(TypeInMethodBodyLineNumber, 17, TypeInMethodBodyLineNumber, 34);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                aggregateRootAsField,
                aggregateRootAsParameterInCtor,
                aggregateRootAsProperty,
                aggregateRootAsReturnValue,
                aggregateRootAsParameterInMethod,
                aggregateRootUsedInMethodBody);
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
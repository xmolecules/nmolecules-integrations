using System.Collections.Generic;
using System.Threading.Tasks;
using NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData;
using NMolecules.Analyzers.ValueObjectAnalyzers;
using Xunit;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<
    NMolecules.Analyzers.ValueObjectAnalyzers.ValueObjectAnalyzer>;

namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests
{
    public class ValueObjectUsesOtherElements
    {
        private const int EntityFieldLineNumber = 14;
        private const int CtorLineNumber = 15;
        private const int PropertyLineNumber = 20;
        private const int MethodLineNumber = 22;
        private const int EntityInMethodBodyLineNumber = 24;

        [Fact]
        public async Task Analyze_WithValueObjectUsesEntity_EmitsCompilerError()
        {
            var testCode = GenerateClass("Entity");
            var entityAsField = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(EntityFieldLineNumber, 37, EntityFieldLineNumber, 43);
            var entityAsParameterInCtor = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(CtorLineNumber, 46, CtorLineNumber, 51);
            var entityAsProperty = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 27, PropertyLineNumber, 32);
            var entityAsReturnValue = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(MethodLineNumber, 27, MethodLineNumber, 37);
            var entityAsParameterInMethod = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(MethodLineNumber, 49, MethodLineNumber, 55);
            var entityUsedInMethodBody = CompilerError(Rules.NoEntitiesInValueObjectsId)
                .WithSpan(EntityInMethodBodyLineNumber, 17, EntityInMethodBodyLineNumber, 27);
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
            var testCode = GenerateClass("Service");
            var entityAsField = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(EntityFieldLineNumber, 38, EntityFieldLineNumber, 45);
            var entityAsParameterInCtor = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(CtorLineNumber, 47, CtorLineNumber, 52);
            var entityAsProperty = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 28, PropertyLineNumber, 33);
            var entityAsReturnValue = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var entityAsParameterInMethod = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            var entityUsedInMethodBody = CompilerError(Rules.NoServicesInValueObjectsId)
                .WithSpan(EntityInMethodBodyLineNumber, 17, EntityInMethodBodyLineNumber, 28);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                entityAsField,
                entityAsParameterInCtor,
                entityAsProperty,
                entityAsReturnValue,
                entityAsParameterInMethod,
                entityUsedInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithValueObjectUsesRepository_EmitsCompilerError()
        {
            var testCode = GenerateClass("Repository");
            var entityAsField = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(EntityFieldLineNumber, 41, EntityFieldLineNumber, 51);
            var entityAsParameterInCtor = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(CtorLineNumber, 50, CtorLineNumber, 55);
            var entityAsProperty = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(PropertyLineNumber, 31, PropertyLineNumber, 36);
            var entityAsReturnValue = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var entityAsParameterInMethod = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            var entityUsedInMethodBody = CompilerError(Rules.NoRepositoriesInValueObjectsId)
                .WithSpan(EntityInMethodBodyLineNumber, 17, EntityInMethodBodyLineNumber, 31);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                entityAsField,
                entityAsParameterInCtor,
                entityAsProperty,
                entityAsReturnValue,
                entityAsParameterInMethod,
                entityUsedInMethodBody);
        }

        [Fact]
        public async Task Analyze_WithValueObjectUsesAggregateRoot_EmitsCompilerError()
        {
            var testCode = GenerateClass("AggregateRoot");
            var entityAsField = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(EntityFieldLineNumber, 44, EntityFieldLineNumber, 57);
            var entityAsParameterInCtor = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(CtorLineNumber, 53, CtorLineNumber, 58);
            var entityAsProperty = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(PropertyLineNumber, 34, PropertyLineNumber, 39);
            var entityAsReturnValue = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(MethodLineNumber, 34, MethodLineNumber, 44);
            var entityAsParameterInMethod = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(MethodLineNumber, 63, MethodLineNumber, 76);
            var entityUsedInMethodBody = CompilerError(Rules.NoAggregateRootsInValueObjectsId)
                .WithSpan(EntityInMethodBodyLineNumber, 17, EntityInMethodBodyLineNumber, 34);
            await VerifyCS.VerifyAnalyzerAsync(testCode,
                entityAsField,
                entityAsParameterInCtor,
                entityAsProperty,
                entityAsReturnValue,
                entityAsParameterInMethod,
                entityUsedInMethodBody);
        }

        private static string GenerateClass(string type)
        {
            var invalidUsageTemplate = new InvalidUsageTemplate
            {
                Session = new Dictionary<string, object> {{"type", type}, {"name", type.ToLowerInvariant()}}
            };
            return invalidUsageTemplate.TransformText();
        }
    }
}
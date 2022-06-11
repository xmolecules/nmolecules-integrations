using System.Collections.Generic;
using System.Threading.Tasks;
using NMolecules.Analyzers.AggregateRootAnalyzers;
using NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData;
using Xunit;
using static NMolecules.Analyzers.Test.ElementNames;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.AggregateRootAnalyzers.AggregateRootAnalyzer>;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests
{
    public class AggregateRootUsesOtherElements
    {
        private const int FieldLineNumber = 14;
        private const int CtorLineNumber = 15;
        private const int PropertyLineNumber = 23;
        private const int MethodLineNumber = 25;
        private const int TypeViolationInMethodBodyLineNumber = 27;

        [Fact]
        public async Task Analyze_WithAggregateRootUsesRepository_EmitsCompilerError()
        {
            var aggregateRoot = GenerateClass(Repository);

            var repositoryAsField = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId).WithSpan(FieldLineNumber, 41, FieldLineNumber, 51);
            var repositoryAsParameterInCtor = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId).WithSpan(CtorLineNumber, 52, CtorLineNumber, 57);
            var repositoryAsReturnValue = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId).WithSpan(MethodLineNumber, 31, MethodLineNumber, 41);
            var repositoryAsParameterInMethod = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId).WithSpan(MethodLineNumber, 57, MethodLineNumber, 67);
            var repositoryAsPropertyType = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId).WithSpan(PropertyLineNumber, 31, PropertyLineNumber, 36);
            var repositoryInMethodBody = CompilerError(Rules.AggregateRootsMustNotUseRepositoriesRuleId)
                .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 31);
            await VerifyCS.VerifyAnalyzerAsync(aggregateRoot,
                repositoryAsField,
                repositoryAsParameterInCtor,
                repositoryAsParameterInMethod,
                repositoryAsReturnValue,
                repositoryAsPropertyType,
                repositoryInMethodBody);
        }
        
        [Fact]
        public async Task Analyze_WithAggregateRootUsesService_EmitsCompilerError()
        {
            var aggregateRoot = GenerateClass(Service);
            var serviceAsField = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId).WithSpan(FieldLineNumber, 38, FieldLineNumber, 45);
            var serviceAsParameterInCtor = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId).WithSpan(CtorLineNumber, 49, CtorLineNumber, 54);
            var serviceAsReturnValue = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId).WithSpan(MethodLineNumber, 28, MethodLineNumber, 38);
            var serviceAsParameterInMethod = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId).WithSpan(MethodLineNumber, 51, MethodLineNumber, 58);
            var serviceAsPropertyType = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId).WithSpan(PropertyLineNumber, 28, PropertyLineNumber, 33);
            var serviceInMethodBody = CompilerError(Rules.AggregateRootsMustNotUseServicesRuleId)
                .WithSpan(TypeViolationInMethodBodyLineNumber, 17, TypeViolationInMethodBodyLineNumber, 28);
            await VerifyCS.VerifyAnalyzerAsync(aggregateRoot,
                serviceAsField,
                serviceAsParameterInCtor,
                serviceAsParameterInMethod,
                serviceAsReturnValue,
                serviceAsPropertyType,
                serviceInMethodBody);
        }
        
        [Fact]
        public async Task Analyze_ValidAggregateRoot_DoesNotEmitAnyError()
        {
            var validAggregateRoot = SampleDataLoader.LoadFromNamespaceOf<AggregateRootUsesOtherElements>("ValidMaximumAggregate.cs");
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
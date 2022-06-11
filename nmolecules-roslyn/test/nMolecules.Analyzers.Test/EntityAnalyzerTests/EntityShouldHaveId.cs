using System.Threading.Tasks;
using NMolecules.Analyzers.EntityAnalyzers;
using Xunit;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static NMolecules.Analyzers.Test.ExpectedResults;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.EntityAnalyzers.EntityAnalyzer>;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests
{
    public class EntityShouldHaveId
    {
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsProperty_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsProperty.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsField_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsField.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsFieldInBaseClass_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsFieldInBaseClass.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsFieldInPartialClass_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsFieldInPartialClass.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsPropertyInBaseClass_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsPropertyInBaseClass.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithIdAsPropertyInPartialClass_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithIdAsPropertyInPartialClass.cs");
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
        }
        
        [Fact]
        public async Task EntityShouldHaveId_WithNoIdProperty_EmitsError()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<EntityUsesOtherElements>("EntityWithoutId.cs");
            var compileError = CompilerError(Rules.EntitiesShouldHaveIdRuleId).WithSpan(6, 18, 6, 33);
            await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
        }
    }
}
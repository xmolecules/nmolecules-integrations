using System.Threading.Tasks;
using Xunit;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.EntityAnalyzers.EntityAnalyzer>;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests
{
    public class ValidEntity
    {
        [Fact]
        public async Task Analyze_ValidEntity_DoesNotEmitAnyError()
        {
            var validAggregateRoot = SampleDataLoader.LoadFromNamespaceOf<ValidEntity>("ValidMaximumEntity.cs");
            await VerifyCS.VerifyAnalyzerAsync(validAggregateRoot);
        }
    }
}
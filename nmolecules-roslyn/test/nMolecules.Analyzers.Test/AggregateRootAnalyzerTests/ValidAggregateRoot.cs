using System.Threading.Tasks;
using Xunit;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.AggregateRootAnalyzers.AggregateRootAnalyzer>;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests
{
    public class ValidAggregateRoot
    {
        [Fact]
        public async Task Analyze_validAggregateRoot_DoesNotEmitAnyError()
        {
            var validAggregateRoot = SampleDataLoader.LoadFromNamespaceOf<ValidAggregateRoot>("ValidMaximumAggregate.cs");
            await VerifyCS.VerifyAnalyzerAsync(validAggregateRoot);
        }
    }
}
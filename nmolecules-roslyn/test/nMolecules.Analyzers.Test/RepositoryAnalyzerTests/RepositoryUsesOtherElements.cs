using System.Threading.Tasks;
using Xunit;
using VerifyCS = NMolecules.Analyzers.Test.Verifiers.CSharpAnalyzerVerifier<NMolecules.Analyzers.RepositoryAnalyzers.RepositoryAnalyzer>;

namespace NMolecules.Analyzers.Test.RepositoryAnalyzerTests
{
    public class RepositoryUsesOtherElements
    {
        [Fact]
        public async Task Analyze_ValidRepository_DoesNotEmitCompilerErrors()
        {
            var validRepository = SampleDataLoader.LoadFromNamespaceOf<RepositoryUsesOtherElements>("ValidMaximumRepository.cs");
            await VerifyCS.VerifyAnalyzerAsync(validRepository);
        }
    }
}
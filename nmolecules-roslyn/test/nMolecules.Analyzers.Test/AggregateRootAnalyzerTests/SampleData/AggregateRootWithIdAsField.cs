using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsField
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
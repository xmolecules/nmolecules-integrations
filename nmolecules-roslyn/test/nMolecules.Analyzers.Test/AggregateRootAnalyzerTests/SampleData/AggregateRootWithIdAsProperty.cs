using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsProperty
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
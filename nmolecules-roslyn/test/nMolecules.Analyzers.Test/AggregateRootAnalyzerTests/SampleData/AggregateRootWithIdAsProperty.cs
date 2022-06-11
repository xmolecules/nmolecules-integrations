using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsProperty
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
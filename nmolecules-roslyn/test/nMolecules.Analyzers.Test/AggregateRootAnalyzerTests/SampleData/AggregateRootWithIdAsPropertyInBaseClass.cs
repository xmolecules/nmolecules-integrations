using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsProperty : AggregateRootWithIdAsPropertyBase
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
    
    public class AggregateRootWithIdAsPropertyBase
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
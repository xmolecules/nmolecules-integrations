using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    public partial class AggregateRootWithIdAsPropertyInPartial
    {
        // SomeDomainLogic
    }
    
    [AggregateRoot]
    public partial class AggregateRootWithIdAsPropertyInPartial
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
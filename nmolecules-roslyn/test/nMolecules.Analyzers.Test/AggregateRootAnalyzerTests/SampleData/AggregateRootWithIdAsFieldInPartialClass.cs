using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    public partial class AggregateRootWithIdAsFieldInPartial
    {
        // SomeDomainLogic
    }
    
    [AggregateRoot]
    public partial class AggregateRootWithIdAsFieldInPartial
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
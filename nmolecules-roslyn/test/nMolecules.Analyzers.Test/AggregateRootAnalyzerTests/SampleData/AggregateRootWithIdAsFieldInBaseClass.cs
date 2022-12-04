using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsField : AggregateRootWithIdAsFieldBase
    {
    }
    
    public class AggregateRootWithIdAsFieldBase
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
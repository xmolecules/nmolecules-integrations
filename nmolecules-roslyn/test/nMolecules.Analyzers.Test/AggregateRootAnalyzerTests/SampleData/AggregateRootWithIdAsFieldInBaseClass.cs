using NMolecules.DDD;
using NMolecules.DDD.Attributes;

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
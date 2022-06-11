using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [AggregateRoot]
    public class AggregateRootWithIdAsField
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
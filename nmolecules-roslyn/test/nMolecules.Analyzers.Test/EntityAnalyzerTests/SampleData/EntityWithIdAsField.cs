using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class EntityWithIdAsField
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
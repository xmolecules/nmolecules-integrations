using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class EntityWithIdAsField
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class EntityWithIdAsFieldInBase : EntityWithIdAsFieldBase
    {
    }
    
    public class EntityWithIdAsFieldBase
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
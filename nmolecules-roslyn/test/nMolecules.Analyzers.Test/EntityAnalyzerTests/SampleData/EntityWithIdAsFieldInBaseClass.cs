using NMolecules.DDD;
using NMolecules.DDD.Attributes;

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
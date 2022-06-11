using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    public partial class EntityWithIdAsFieldInPartial
    {
        // SomeDomainLogic
    }
    
    [Entity]
    public partial class EntityWithIdAsFieldInPartial
    {
        [Identity] 
        public string Id = "SomeId";
    }
}
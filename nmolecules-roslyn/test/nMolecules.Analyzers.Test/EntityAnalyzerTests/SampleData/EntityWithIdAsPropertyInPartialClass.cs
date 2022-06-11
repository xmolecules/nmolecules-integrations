using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    public partial class EntityWithIdAsPropertyInPartial
    {
        // SomeDomainLogic
    }
    
    [Entity]
    public partial class EntityWithIdAsPropertyInPartial
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
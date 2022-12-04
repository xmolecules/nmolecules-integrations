using NMolecules.DDD;

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
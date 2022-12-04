using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class EntityWithIdAsProperty
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
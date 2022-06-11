using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class EntityWithIdAsProperty
    {
        [Identity] 
        public string Id { get; } = "SomeId";
    }
}
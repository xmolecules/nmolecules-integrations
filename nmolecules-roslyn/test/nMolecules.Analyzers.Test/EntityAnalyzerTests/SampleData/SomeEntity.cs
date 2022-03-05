using NMolecules.DDD;

namespace NMolecules.Analyzers.Test.EntityAnalyzerTests.SampleData
{
    [Entity]
    public class SomeEntity
    {
        public SomeEntity(int id)
        {
            Id = id;
        }

        [Identity] public int Id { get; }
    }

    [Entity]
    public class MyEntity
    {
    }
}
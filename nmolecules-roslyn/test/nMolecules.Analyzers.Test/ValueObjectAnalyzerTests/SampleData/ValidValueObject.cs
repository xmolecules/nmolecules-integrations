namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData
{
    using System;
    using NMolecules.DDD;
    
    [ValueObject]
    public sealed class ValiedValueObject : IEquatable<ValiedValueObject>
    {
        private const string SomePrivateConst = "const1";
        public const string SomePublicConst = "const1";
        public ValiedValueObject(string value)
        {
            Value = value;
        }
        
        public string Value { get; }
        
        public bool Equals(ValiedValueObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ValiedValueObject other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
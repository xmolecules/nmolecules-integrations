namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData
{
    using System;
    using NMolecules.DDD;
    
    [ValueObject]
    public sealed class InvalidValueObject : IEquatable<InvalidValueObject>
    {
        private string value;
        public InvalidValueObject(string value)
        {
            this.value = value;
        }

        public string Value => value;
        
        public bool Equals(InvalidValueObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is InvalidValueObject other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
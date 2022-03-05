namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData
{
    using System;
    using NMolecules.DDD;
    
    [ValueObject]
    public sealed class ValueObjectNotSealed
    {
        public ValueObjectNotSealed(string value)
        {
            Value = value;
        }
        
        public string Value { get; }
        
        public bool Equals(ValueObjectNotSealed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ValueObjectNotSealed other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}

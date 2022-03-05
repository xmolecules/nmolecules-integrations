namespace NMolecules.Analyzers.Test.ValueObjectAnalyzerTests.SampleData
{
    using System;
    using NMolecules.DDD;
    
    [ValueObject]
    public sealed class ValueObjectWithPublicPropertyGetter : IEquatable<ValueObjectWithPublicPropertyGetter>
    {
        public ValueObjectWithPublicPropertyGetter(string value)
        {
            Value = value;
        }
        
        public string Value { get; set; }
        
        public bool Equals(ValueObjectWithPublicPropertyGetter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ValueObjectWithPublicPropertyGetter other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
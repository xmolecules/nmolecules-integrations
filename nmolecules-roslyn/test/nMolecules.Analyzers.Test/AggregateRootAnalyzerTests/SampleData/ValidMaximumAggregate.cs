using System;
using NMolecules.DDD;
using NMolecules.DDD.Attributes;

namespace NMolecules.Analyzers.Test.AggregateRootAnalyzerTests.SampleData
{
    [ValueObject]
    public sealed class ValueObject : IEquatable<ValueObject>
    {
        public string Value { get; }

        public ValueObject(string value)
        {
            Value = value;
        }

        public bool Equals(ValueObject other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value;
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is ValueObject other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();
    }
    
    [Entity]
    public class Entity
    {
        public Entity(string id)
        {
            Id = id;
        }

        [Identity]
        public string Id { get; }
    }
    
    [AggregateRoot]
    public class ValidMaximumAggregate
    {
        private Entity entity;
        private ValueObject valueObject;

        public ValidMaximumAggregate(Entity entity, ValueObject valueObject)
        {
            this.entity = entity;
            this.valueObject = valueObject;
        }

        [Identity] 
        public string Id { get; set; } = string.Empty;

        public Entity Entity => entity;

        public ValueObject ValueObject => valueObject;

        public Entity SomeMethod1(Entity entity, ValueObject valueObject)
        {
            this.entity = entity;
            this.valueObject = valueObject;
            return this.entity;
        }
        
        public ValueObject SomeMethod2(Entity entity, ValueObject valueObject)
        {
            this.entity = entity;
            this.valueObject = valueObject;
            return this.valueObject;
        }

        public void SomeMethod3()
        {
            var someValueObject = new ValueObject("1");
            var someEntity = new Entity("2");
        }
    }
}
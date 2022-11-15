using NextStation.Data.Game.Nbt;
using SharpNBT;

namespace NextStation.Data.Game.Property.Dynamic
{
    public abstract record DynamicPropertyTypeBase
    {
        public readonly string Name;

        protected DynamicPropertyTypeBase(string name)
        {
            Name = name;
        }
    }

    public sealed record DynamicPropertyType<T> : DynamicPropertyTypeBase
        where T : notnull
    {
        public DynamicPropertyType(string name)
            : base(name) { }
    }

    public abstract class DynamicPropertyBase : INbt
    {
        public readonly DynamicPropertyTypeBase Type;

        public abstract dynamic PropertyValue { get; }

        public abstract Tag ToNbt();

        public abstract void LoadFromNbt(Tag tag);

        protected DynamicPropertyBase(DynamicPropertyTypeBase type)
        {
            Type = type;
        }
    }

    public abstract class DynamicPropertyBase<T> : DynamicPropertyBase
        where T : notnull
    {
        public T Value;

        public override dynamic PropertyValue => Value;

        public DynamicPropertyBase(DynamicPropertyTypeBase type, T value)
            : base(type)
        {
            Value = value;
        }
    }

    public class DynamicProperties : INbt
    {
        const string tagName = "Properties";

        List<DynamicPropertyBase> _properties = new();

        public DynamicProperties() { }

        public DynamicProperties(Tag tag)
        {
            LoadFromNbt(tag);
        }

        public void LoadFromNbt(Tag tag)
        {
            if (tag is not CompoundTag) throw new NbtTagTypeException(tag, TagType.Compound);
            if (tag.Name != tagName) throw new NbtTagNameException(tag, tagName);
            CompoundTag compoundTag = (CompoundTag)tag;
            _properties = new();
            foreach(Tag content in compoundTag)
            {
                // 未完成
            }
        }

        public Tag ToNbt()
        {
            CompoundTag result = new CompoundTag(tagName);
            foreach(DynamicPropertyBase property in _properties)
            {
                result.Add(property.ToNbt());
            }
            return result;
        }
    }
}

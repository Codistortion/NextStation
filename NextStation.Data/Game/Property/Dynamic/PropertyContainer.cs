using NextStation.Data.Game.Nbt;
using SharpNBT;

namespace NextStation.Data.Game.Property.Dynamic
{
    public class PropertyContainer : INbt
    {
        private readonly List<DynamicPropertyBase> _properties = new();

        public PropertyContainer() { }

        public Tag ToNbt()
        {
            CompoundTag result = new(null);
            foreach (DynamicPropertyBase property in _properties)
            {
                result.Add(property.ToNbt());
            }
            return result;
        }

        public void LoadFromNbt(Tag tag)
        {
            if (tag is not CompoundTag) throw new NbtTagTypeException(tag, TagType.Compound);
            CompoundTag compound = (CompoundTag)tag;
            _properties.Clear();
            foreach(Tag content in compound)
            {
                DynamicPropertyBase? property = PropertyBuilder.GetProperty(content);
                if (property is not null) _properties.Add(property);
            }
        }

        public PropertyContainer(CompoundTag tag)
        {
            LoadFromNbt(tag);
        }
    }
}
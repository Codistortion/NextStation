using NextStation.Data.Game.Nbt;
using SharpNBT;

namespace NextStation.Data.Game.Property.Dynamic
{
    /// <summary>
    /// 属性构造器
    /// </summary>
    public static class PropertyBuilder
    {
        /// <summary>
        /// 根据NBT标签构造属性
        /// </summary>
        /// <param name="tag">NBT标签</param>
        /// <returns>动态属性</returns>
        public static DynamicPropertyBase? GetProperty(Tag tag)
        {
            if (tag is EndTag) return null;
            else if (tag is ByteTag byteTag) return new ByteDynamicProperty(new DynamicPropertyType<byte>(tag.Name), byteTag.Value);
            else if (tag is ShortTag shortTag) return new ShortDynamicProperty(new DynamicPropertyType<short>(tag.Name), shortTag.Value);
            else if (tag is IntTag intTag) return new IntegerDynamicProperty(new DynamicPropertyType<int>(tag.Name), intTag.Value);
            else if (tag is LongTag longTag) return new LongDynamicProperty(new DynamicPropertyType<long>(tag.Name), longTag.Value);
            else if (tag is FloatTag floatTag) return new FloatDynamicProperty(new DynamicPropertyType<float>(tag.Name), floatTag.Value);
            else if (tag is DoubleTag doubleTag) return new DoubleDynamicProperty(new DynamicPropertyType<double>(tag.Name), doubleTag.Value);
            else if (tag is ByteArrayTag byteArrayTag) return new ByteArrayDynamicProperty(new DynamicPropertyType<byte[]>(tag.Name), byteArrayTag.ToArray());
            else if (tag is StringTag stringTag) return new StringDynamicProperty(new DynamicPropertyType<string>(tag.Name), stringTag.Value);
            else if (tag is ListTag listTag) return new ListDynamicProperty(new DynamicPropertyType<Container>(tag.Name), new Container(listTag));
            else if (tag is CompoundTag compoundTag) return new CompoundDynamicProperty(new DynamicPropertyType<PropertyContainer>(tag.Name), new PropertyContainer(compoundTag));
            else if (tag is IntArrayTag intArrayTag) return new IntArrayDynamicProperty(new DynamicPropertyType<int[]>(tag.Name), intArrayTag.ToArray());
            else if (tag is LongArrayTag longArrayTag) return new LongArrayDynamicProperty(new DynamicPropertyType<long[]>(tag.Name), longArrayTag.ToArray());
            else return null;
        }
    }
}
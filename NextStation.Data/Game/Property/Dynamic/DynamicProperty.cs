using NextStation.Data.Game.Nbt;
using SharpNBT;

// 各种动态属性，类型与NBT标签的类型对应
namespace NextStation.Data.Game.Property.Dynamic
{
    public class ByteDynamicProperty : DynamicPropertyBase<byte>
    {
        public ByteDynamicProperty(DynamicPropertyType<byte> type, byte value)
            : base(type, value) { }

        public override Tag ToNbt() => new ByteTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not ByteTag) throw new NbtTagTypeException(tag, TagType.Byte);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            ByteTag byteTag = (ByteTag)tag;
            Value = byteTag.Value;
        }
    }

    public class ShortDynamicProperty : DynamicPropertyBase<short>
    {
        public ShortDynamicProperty(DynamicPropertyType<short> type, short value)
            : base(type, value) { }

        public override Tag ToNbt() => new ShortTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not ShortTag) throw new NbtTagTypeException(tag, TagType.Short);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            ShortTag shortTag = (ShortTag)tag;
            Value = shortTag.Value;
        }
    }

    public class IntegerDynamicProperty : DynamicPropertyBase<int>
    {
        public IntegerDynamicProperty(DynamicPropertyType<int> type, int value)
            : base(type, value) { }

        public override Tag ToNbt() => new IntTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not IntTag) throw new NbtTagTypeException(tag, TagType.Int);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            IntTag intTag = (IntTag)tag;
            Value = intTag.Value;
        }
    }

    public class LongDynamicProperty : DynamicPropertyBase<long>
    {
        public LongDynamicProperty(DynamicPropertyType<long> type, long value)
            : base(type, value) { }

        public override Tag ToNbt() => new LongTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not LongTag) throw new NbtTagTypeException(tag, TagType.Long);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            LongTag longTag = (LongTag)tag;
            Value = longTag.Value;
        }
    }

    public class FloatDynamicProperty : DynamicPropertyBase<float>
    {
        public FloatDynamicProperty(DynamicPropertyType<float> type, float value)
            : base(type, value) { }

        public override Tag ToNbt() => new FloatTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not FloatTag) throw new NbtTagTypeException(tag, TagType.Float);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            FloatTag floatTag = (FloatTag)tag;
            Value = floatTag.Value;
        }
    }

    public class DoubleDynamicProperty : DynamicPropertyBase<double>
    {
        public DoubleDynamicProperty(DynamicPropertyType<double> type, double value)
            : base(type, value) { }

        public override Tag ToNbt() => new DoubleTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not DoubleTag) throw new NbtTagTypeException(tag, TagType.Double);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            DoubleTag doubleTag = (DoubleTag)tag;
            Value = doubleTag.Value;
        }
    }

    public class ByteArrayDynamicProperty : DynamicPropertyBase<byte[]>
    {
        public ByteArrayDynamicProperty(DynamicPropertyType<byte[]> type, byte[] value)
            : base(type, value) { }

        public override Tag ToNbt() => new ByteArrayTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not ByteArrayTag) throw new NbtTagTypeException(tag, TagType.ByteArray);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            ByteArrayTag byteArrayTag = (ByteArrayTag)tag;
            Value = byteArrayTag.ToArray();
        }
    }

    public class StringDynamicProperty : DynamicPropertyBase<string>
    {
        public StringDynamicProperty(DynamicPropertyType<string> type, string value)
            : base(type, value) { }

        public override Tag ToNbt() => new StringTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not StringTag) throw new NbtTagTypeException(tag, TagType.String);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            StringTag stringTag = (StringTag)tag;
            Value = stringTag.Value;
        }
    }
    
    public class ListDynamicProperty : DynamicPropertyBase<Container>
    {
        // 注意：List的内容类型只能是Compound
        // 这是因为List被规定只能用作物品容器

        public ListDynamicProperty(DynamicPropertyType<Container> type, Container value)
            : base(type, value) { }

        public override Tag ToNbt() => Value.ToNbt();

        public override void LoadFromNbt(Tag tag)
        {
            Value.LoadFromNbt(tag);
        }
    }

    public class CompoundDynamicProperty : DynamicPropertyBase<PropertyContainer>
    {
        // Compound可以表示 物品 or 物块 or 物品的属性集

        public CompoundDynamicProperty(DynamicPropertyType<PropertyContainer> type, PropertyContainer value)
            : base(type, value) { }

        public override Tag ToNbt() => Value.ToNbt();

        public override void LoadFromNbt(Tag tag)
        {
            Value.LoadFromNbt(tag);
        }
    }

    public class IntArrayDynamicProperty : DynamicPropertyBase<int[]>
    {
        public IntArrayDynamicProperty(DynamicPropertyType<int[]> type, int[] value)
            : base(type, value) { }

        public override Tag ToNbt() => new IntArrayTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not IntArrayTag) throw new NbtTagTypeException(tag, TagType.IntArray);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            IntArrayTag intArrayTag = (IntArrayTag)tag;
            Value = intArrayTag.ToArray();
        }
    }

    public class LongArrayDynamicProperty : DynamicPropertyBase<long[]>
    {
        public LongArrayDynamicProperty(DynamicPropertyType<long[]> type, long[] value)
            : base(type, value) { }

        public override Tag ToNbt() => new LongArrayTag(Type.Name, Value);

        public override void LoadFromNbt(Tag tag)
        {
            if (tag is not LongArrayTag) throw new NbtTagTypeException(tag, TagType.LongArray);
            if (tag.Name != Type.Name) throw new NbtTagNameException(tag, Type.Name);
            LongArrayTag longArrayTag = (LongArrayTag)tag;
            Value = longArrayTag.ToArray();
        }
    }
}
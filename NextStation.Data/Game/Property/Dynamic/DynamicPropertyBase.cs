using NextStation.Data.Game.Nbt;
using SharpNBT;

namespace NextStation.Data.Game.Property.Dynamic
{
    /// <summary>
    /// 动态属性的类型(名称)
    /// </summary>
    public abstract record DynamicPropertyTypeBase
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public readonly string Name;

        protected DynamicPropertyTypeBase(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// 具有特定数据类型的属性类型
    /// </summary>
    /// <typeparam name="T">值的数据类型</typeparam>
    public sealed record DynamicPropertyType<T> : DynamicPropertyTypeBase
        where T : notnull
    {
        public DynamicPropertyType(string name)
            : base(name) { }
    }

    /// <summary>
    /// 动态属性
    /// </summary>
    public abstract class DynamicPropertyBase : INbt
    {
        /// <summary>
        /// 类型
        /// </summary>
        public readonly DynamicPropertyTypeBase Type;

        /// <summary>
        /// 值
        /// </summary>
        public abstract dynamic PropertyValue { get; }

        public abstract Tag ToNbt();

        public abstract void LoadFromNbt(Tag tag);

        protected DynamicPropertyBase(DynamicPropertyTypeBase type)
        {
            Type = type;
        }
    }

    /// <summary>
    /// 具有特定数据类型的动态属性
    /// </summary>
    /// <typeparam name="T">值的数据类型</typeparam>
    public abstract class DynamicPropertyBase<T> : DynamicPropertyBase
        where T : notnull
    {
        /// <summary>
        /// 值（已经指明数据类型）
        /// </summary>
        public T Value;

        public override dynamic PropertyValue => Value;

        public DynamicPropertyBase(DynamicPropertyTypeBase type, T value)
            : base(type)
        {
            Value = value;
        }
    }

    /// <summary>
    /// 动态属性集
    /// </summary>
    public class DynamicProperties : INbt
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        const string tagName = "Properties";

        public PropertyContainer Properties = new PropertyContainer();

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
            Properties = new(compoundTag);
        }

        public Tag ToNbt()
        {
            Tag result = Properties.ToNbt();
            result.Name = tagName;
            return result;
        }
    }
}

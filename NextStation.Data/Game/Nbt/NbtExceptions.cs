using SharpNBT;

namespace NextStation.Data.Game.Nbt
{
    /// <summary>
    /// 传入的NBT标签存在错误
    /// </summary>
    public class NbtTagException : Exception
    {
        /// <summary>
        /// 出错的标签
        /// </summary>
        public readonly Tag NbtTag;

        /// <summary>
        /// 构造函数，使用默认格式的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        public NbtTagException(Tag tag)
            : base($"类型为{tag.Type}标签{tag.Name}存在问题.\n标签SNBT:\n{tag.Stringify}")
        {
            NbtTag = tag;
        }

        /// <summary>
        /// 构造函数，使用指定的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        /// <param name="message">错误信息</param>
        public NbtTagException(Tag tag, string? message)
            : base(message)
        {
            NbtTag = tag;
        }
    }

    /// <summary>
    /// 传入的NBT标签类型错误
    /// </summary>
    public class NbtTagTypeException : NbtTagException
    {
        /// <summary>
        /// 正确的标签类型
        /// </summary>
        public readonly TagType TargetType;

        /// <summary>
        /// 构造函数，使用默认格式的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        /// <param name="targetType">正确的标签类型</param>
        public NbtTagTypeException(Tag tag, TagType targetType)
            : base(tag, $"标签{tag.Name}的类型应该为{targetType},而不是{tag.Type}")
        {
            TargetType = targetType;
        }

        /// <summary>
        /// 构造函数，使用指定的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        /// <param name="targetType">正确的标签类型</param>
        /// <param name="message">错误信息</param>
        public NbtTagTypeException(Tag tag, TagType targetType, string? message)
            : base(tag, message)
        {
            TargetType = targetType;
        }
    }

    /// <summary>
    /// 传入的NBT标签名称错误
    /// </summary>
    public class NbtTagNameException : NbtTagException
    {
        /// <summary>
        /// 正确的标签名称
        /// </summary>
        public readonly string TargetName;

        /// <summary>
        /// 构造函数，使用默认格式的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        /// <param name="targetName">正确的标签名称</param>
        public NbtTagNameException(Tag tag, string targetName)
            : base(tag, $"标签{tag.Name}的名称应该为{targetName}")
        {
            TargetName = targetName;
        }

        /// <summary>
        /// 构造函数，使用指定的错误信息
        /// </summary>
        /// <param name="tag">出错的标签</param>
        /// <param name="targetName">正确的标签名称</param>
        /// <param name="message">错误信息</param>
        public NbtTagNameException(Tag tag, string targetName, string? message)
            : base(tag, message)
        {
            TargetName = targetName;
        }
    }
}
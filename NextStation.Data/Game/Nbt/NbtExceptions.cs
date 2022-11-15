using SharpNBT;

namespace NextStation.Data.Game.Nbt
{
    public class NbtTagException : Exception
    {
        public readonly Tag NbtTag;

        public NbtTagException(Tag tag)
            : base($"类型为{tag.Type}标签{tag.Name}存在问题.\n标签SNBT:\n{tag.Stringify}")
        {
            NbtTag = tag;
        }

        public NbtTagException(Tag tag, string? message)
            : base(message)
        {
            NbtTag = tag;
        }
    }

    public class NbtTagTypeException : NbtTagException
    {
        public readonly TagType TargetType;

        public NbtTagTypeException(Tag tag, TagType targetType)
            : base(tag, $"标签{tag.Name}的类型应该为{targetType},而不是{tag.Type}")
        {
            TargetType = targetType;
        }

        public NbtTagTypeException(Tag tag, TagType targetType, string? message)
            : base(tag, message)
        {
            TargetType = targetType;
        }
    }

    public class NbtTagNameException : NbtTagException
    {
        public readonly string TargetName;

        public NbtTagNameException(Tag tag, string targetName)
            : base(tag, $"标签{tag.Name}的名称应该为{targetName}")
        {
            TargetName = targetName;
        }

        public NbtTagNameException(Tag tag, string targetName, string? message)
            : base(tag, message)
        {
            TargetName = targetName;
        }
    }
}
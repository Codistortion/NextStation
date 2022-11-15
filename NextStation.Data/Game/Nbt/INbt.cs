using SharpNBT;

namespace NextStation.Data.Game.Nbt
{
    /// <summary>
    /// 能够以NBT格式储存
    /// </summary>
    public interface INbt
    {
        /// <summary>
        /// 转化为NBT
        /// </summary>
        /// <returns>NBT</returns>
        public Tag ToNbt();

        /// <summary>
        /// 通过NBT加载内容
        /// </summary>
        /// <param name="tag">NBT标签</param>
        public void LoadFromNbt(Tag tag);
    }
}

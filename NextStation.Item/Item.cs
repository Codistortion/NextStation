using NextStation.Data.Game.Property.Static;

namespace NextStation.Item
{
    /// <summary>
    /// 存储物品信息
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// 物品ID,不可更改
        /// </summary>
        public abstract int ID { get; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 物品描述
        /// </summary>
        public abstract string Description { get; }

        public abstract StaticProperties StaticProperties { get; }
    }
}
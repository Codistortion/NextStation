using NextStation.Data.Game.Property.Static;

namespace NextStation.Item.Property.Static
{
    public static class StaticPropertyTypes
    {
        public static StaticPropertyType GetTypeByID(int id) => id switch
        {
            0 => Mass,
            1 => ExtraMass,
            2 => Stackable,
            3 => Eatable,
            4 => Breakable,
            5 => SingleUse,
            _ => throw new ArgumentOutOfRangeException(nameof(id)),
        };

        /// <summary>
        /// 单体质量(g). 对于可堆叠物品,总质量=单个物品质量*数量.
        /// </summary>
        public static readonly StaticPropertyType Mass = new(0, 1000, 0);

        /// <summary>
        /// 额外质量(g). 对于有耐久度的物品,总质量=单体质量+额外质量*(当前耐久度/总耐久度). 最终结果自动取整.
        /// </summary>
        public static readonly StaticPropertyType ExtraMass = new(1, 0, 0);

        /// <summary>
        /// 可堆叠,值为-1时可无限堆叠,值大于1时为最大堆叠数量
        /// </summary>
        public static readonly StaticPropertyType Stackable = new(2, -1, 1);

        /// <summary>
        /// 可以食用
        /// </summary>
        public static readonly StaticPropertyType Eatable = new(3, -1, 0);

        /// <summary>
        /// 有耐久度,其值为最大耐久度
        /// </summary>
        public static readonly StaticPropertyType Breakable = new(4, 1000, -1);

        /// <summary>
        /// 一次性使用,1为一次性,-1为可重复使用
        /// </summary>
        public static readonly StaticPropertyType SingleUse = new(5, 1, -1);
    }
}
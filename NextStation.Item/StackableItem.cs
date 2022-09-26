namespace NextStation.Item
{
    /// <summary>
    /// 可堆叠物品
    /// </summary>
    public class StackableItem : Item
    {
        /// <summary>
        /// 物品最大堆叠数量
        /// </summary>
        public readonly int maximum;

        /// <summary>
        /// 物品数量
        /// </summary>
        public int count;

    }
}

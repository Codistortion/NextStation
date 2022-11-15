using NextStation.Data.Game.Property.Dynamic;

namespace NextStation.Item.Property.Dynamic
{
    /// <summary>
    /// 动态属性类型生成器，提供预设的属性类型
    /// </summary>
    /// <typeparam name="T">值的数据类型</typeparam>
    public sealed partial record DynamicPropertyTypes<T>
        where T : notnull
    {
        /// <summary>
        /// 根据名称查找属性类型
        /// </summary>
        /// <param name="name">类型名称</param>
        /// <returns>属性类型</returns>
        /// <exception cref="ArgumentOutOfRangeException">当不存在与给定的名称和数据类型匹配的属性类型时产生此错误</exception>
        public static DynamicPropertyType<T> GetTypeFromName(string name)
        {
            DynamicPropertyType<T> result = new(name);
            if (allTypes.Contains(result)) return result;
            throw new ArgumentOutOfRangeException(nameof(name));
        }

        public readonly static DynamicPropertyType<int> StackCount = new("Count");
        public readonly static DynamicPropertyType<int> Durability = new("Durability");

        private readonly static DynamicPropertyTypeBase[] allTypes =
        {
            StackCount,
            Durability,
        };
    }
}
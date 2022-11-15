namespace NextStation.Data.Game.Property.Static
{
    /// <summary>
    /// 表示静态属性类型,请通过静态字段获取属性类型
    /// </summary>
    public record struct StaticPropertyType
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        public readonly int ID;

        /// <summary>
        /// 默认值(有此属性时)
        /// </summary>
        public readonly int DefaultValue;

        /// <summary>
        /// 默认值(无此属性时)
        /// </summary>
        public readonly int NotFoundValue;

        /// <summary>
        /// 内部专用构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="defaultValue">默认值(有此属性时)</param>
        /// <param name="notFoundValue">默认值(无此属性时)</param>
        public StaticPropertyType(int id, int defaultValue, int notFoundValue)
        {
            ID = id;
            DefaultValue = defaultValue;
            NotFoundValue = notFoundValue;
        }
    }

    /// <summary>
    /// 表示静态属性(类型和值)
    /// </summary>
    public record struct StaticProperty
    {
        /// <summary>
        /// 属性类型
        /// </summary>
        public readonly StaticPropertyType Type;

        /// <summary>
        /// 值
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// 构造静态属性
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">值</param>
        public StaticProperty(StaticPropertyType type, int value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// 使用默认值构造静态属性
        /// </summary>
        /// <param name="type">类型</param>
        public StaticProperty(StaticPropertyType type)
        {
            Type = type;
            Value = type.DefaultValue;
        }
    }

    /// <summary>
    /// 静态属性的集合
    /// </summary>
    public struct StaticProperties
    {
        /// <summary>
        /// 结构内部储存静态属性的列表
        /// </summary>
        private readonly StaticProperty[] _properties;

        /// <summary>
        /// 构造函数. 当输入多次同一类型的属性时,仅第一个有效
        /// </summary>
        /// <param name="properties">属性</param>
        public StaticProperties(params StaticProperty[] properties)
        {
            _properties = properties;
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>值</returns>
        public int this[StaticPropertyType type]
        {
            get
            {
                foreach(var property in _properties)
                {
                    if(property.Type == type) return property.Value;
                }
                return type.NotFoundValue;
            }
        }

        /// <summary>
        /// 检查属性是否存在
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>若存在属性但是值与不存在默认值相等,也视为不存在</returns>
        public bool Contains(StaticPropertyType type)
        {
            return this[type] == type.NotFoundValue;
        }
    }
}

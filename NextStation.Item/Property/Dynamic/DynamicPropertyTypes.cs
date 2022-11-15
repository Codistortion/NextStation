using NextStation.Data.Game.Property.Dynamic;

namespace NextStation.Item.Property.Dynamic
{
    public sealed partial record DynamicPropertyTypes<T>
        where T : notnull
    {
        public static DynamicPropertyType<T> GetTypeFromName(string name)
        {
            DynamicPropertyType<T> result = new(name);
            if (allTypes.Contains(result)) return result;
            throw new ArgumentOutOfRangeException(nameof(name));
        }

        public readonly static DynamicPropertyType<int> StackCount = new("Count");
        public readonly static DynamicPropertyType<int> Durability = new("Durability");

        private static DynamicPropertyTypeBase[] allTypes =
        {
            StackCount,
            Durability,
        };
    }
}
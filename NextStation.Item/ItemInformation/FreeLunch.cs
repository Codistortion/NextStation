using NextStation.Data.Game.Property.Static;
using NextStation.Item.Property.Static;

namespace NextStation.Item.ItemInformation
{
    public class FreeLunch : Item
    {
        public const int id = -3;
        public override int ID => id;

        public override string Name => "0元购";

        public override string Description => "黄熙涵的天才发明";

        public override StaticProperties StaticProperties =>
            new(new StaticProperty(StaticPropertyTypes.Mass, 300),
                new StaticProperty(StaticPropertyTypes.Eatable),
                new StaticProperty(StaticPropertyTypes.SingleUse));
    }
}

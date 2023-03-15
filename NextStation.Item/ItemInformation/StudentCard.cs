using NextStation.Data.Game.Property.Static;
using NextStation.Item.Property.Static;

namespace NextStation.Item.ItemInformation
{
    public class StudentCard : Item
    {
        public const int id = -2; 
        public override int ID => id;

        public override string Name => "傅炯文的饭卡";

        public override string Description => "傅炯文有时会忘记自己把饭卡放在哪里了";

        public override StaticProperties StaticProperties =>
            new(new StaticProperty(StaticPropertyTypes.Mass, 50));
    }
}

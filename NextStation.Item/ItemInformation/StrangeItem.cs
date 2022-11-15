﻿using NextStation.Data.Game.Property.Static;
using NextStation.Item.Property.Static;

namespace NextStation.Item.ItemInformation
{
    public class StrangeItem : ItemBase
    {
        public override int ID => -1;

        public override string Name => "奇怪的物品";

        public override string Description => "没人知道这是什么";

        public override StaticProperties StaticProperties =>
            new(new StaticProperty(StaticPropertyTypes.Stackable));
    }
}

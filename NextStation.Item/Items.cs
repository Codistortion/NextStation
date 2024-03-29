﻿using NextStation.Item.ItemInformation;

namespace NextStation.Item
{
    /// <summary>
    /// 提供物品信息
    /// </summary>
    public static class Items
    {
        public static Item GetItemById(int id)
        {
            // 待完成
            return id switch
            {
                StrangeItem.id => new StrangeItem(),
                FreeLunch.id => new FreeLunch(),
                _ => new StrangeItem(),
            };
        }
    }
}

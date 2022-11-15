using NextStation.Data.Game.Nbt;
using SharpNBT;

namespace NextStation.Data.Game.Property.Dynamic
{
    public class Container : INbt
    {
        private readonly List<PropertyContainer> _items = new();

        public Tag ToNbt()
        {
            ListTag result = new(null, TagType.Compound);
            foreach (var item in _items) result.Add(item.ToNbt());
            return result;
        }

        public void LoadFromNbt(Tag tag)
        {
            if (tag is not ListTag) throw new NbtTagTypeException(tag, TagType.List);
            ListTag listTag = (ListTag)tag;
            if (listTag.ChildType != TagType.Compound) throw new NbtTagTypeException(listTag, TagType.List, "列表类型必须为Compound");
            _items.Clear();
            foreach (Tag content in listTag)
            {
                PropertyContainer item = new();
                item.LoadFromNbt(content);
                _items.Add(item);
            }
        }

        public Container(ListTag tag)
        {
            LoadFromNbt(tag);
        }
    }
}
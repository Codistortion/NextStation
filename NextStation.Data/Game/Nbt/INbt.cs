using SharpNBT;

namespace NextStation.Data.Game.Nbt
{
    public interface INbt
    {
        public Tag ToNbt();

        public void LoadFromNbt(Tag tag);
    }
}

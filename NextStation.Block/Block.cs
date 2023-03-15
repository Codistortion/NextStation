namespace NextStation.Block
{
    public abstract class Block
    {
        public abstract int ID { get; }

        public abstract int ItemID { get; }

        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int H { get; protected set; }
    }
}
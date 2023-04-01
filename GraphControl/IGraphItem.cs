namespace GraphControl
{
    public interface IGraphItem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int ZIndex { get; init; }
    }
}

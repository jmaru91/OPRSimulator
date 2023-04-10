namespace OPR
{
    public class Terrain
    {
        readonly Rect m_rect;

        public TerrainKind Kind { get; }

        public float Elevation { get; }

        public Terrain(Rect rect, TerrainKind kind, float elevation)
        {
            m_rect = rect;
            Kind = kind;
            Elevation = elevation;
        }
    }
}
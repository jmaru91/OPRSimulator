namespace OPR
{
    public class Objective
    {
        readonly Rect m_rect;

        public Player? Owner { get; }

        public Objective(Rect rect)
        {
            m_rect = rect;
        }
    }
}
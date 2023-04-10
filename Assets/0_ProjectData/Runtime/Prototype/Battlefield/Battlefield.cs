using UnityEngine;
using Zenject;

namespace OPR
{
    public class Battlefield : IInitializable
    {
        readonly Rect m_rect;

        public Battlefield(Rect rect)
        {
            m_rect = rect;
        }

        public void Initialize()
        {
            Debug.Log("I'm alive");
        }

        public class Factory : PlaceholderFactory<Battlefield>
        {
        }
    }
}
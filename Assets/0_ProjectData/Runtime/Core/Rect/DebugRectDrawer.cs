using UnityEngine;
using Zenject;

namespace OPR
{
    public class DebugRectDrawer : MonoBehaviour
    {
        Rect m_rect;

        [Inject]
        public void Construct(Rect rect)
        {
            m_rect = rect;
        }

        void OnDrawGizmos()
        {
            Debug.Log("OnDrawGizmos");
            Gizmos.DrawLine(m_rect.A, m_rect.B);
            Gizmos.DrawLine(m_rect.B, m_rect.C);
            Gizmos.DrawLine(m_rect.C, m_rect.D);
            Gizmos.DrawLine(m_rect.D, m_rect.A);
        }
    }
}
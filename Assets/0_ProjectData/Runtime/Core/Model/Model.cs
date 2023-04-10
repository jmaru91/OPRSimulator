using System;
using UnityEngine;

namespace OPR
{
    public class Model
    {
        readonly Rect m_rect;

        public ModelStats Stats { get; }
        public bool IsAlive { get; private set; }

        public event Action OnMoved;
        public event Action OnKilled;
        
        public Model(Rect rect, ModelStats stats)
        {
            m_rect = rect;
            Stats = stats;
        }

        public void Move(Vector2 to)
        {
            m_rect.Move(to);
            OnMoved?.Invoke();
        }

        public void Kill()
        {
            IsAlive = false;
            OnKilled?.Invoke();
        } 
    }
}
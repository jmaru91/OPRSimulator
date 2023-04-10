using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OPR
{
    public class Rect
    {
        public Vector2 Center { get; private set; }
        public Vector2 Size { get; private set; }
        public Vector2 A { get; private set; }
        public Vector2 B { get; private set; }
        public Vector2 C { get; private set; }
        public Vector2 D { get; private set; }
        public float Angle { get; private set; }

        public Rect(Transform transform)
            : this(transform.position, transform.localScale)
        {
        }
        
        public Rect(Vector2 center, Vector2 size)
        {
            Center = center;
            Size = size;
            Angle = 0;

            A = new Vector2(center.x + size.x / 2, center.y + size.y / 2);
            B = new Vector2(center.x + size.x / 2, center.y - size.y / 2);
            C = new Vector2(center.x - size.x / 2, center.y - size.y / 2);
            D = new Vector2(center.x - size.x / 2, center.y + size.y / 2);
        }

        public void Rotate(float degrees)
        {
            Angle = degrees;
            A = RotatePoint(A, Center, Mathf.Deg2Rad * degrees);
            B = RotatePoint(B, Center, Mathf.Deg2Rad * degrees);
            C = RotatePoint(C, Center, Mathf.Deg2Rad * degrees);
            D = RotatePoint(D, Center, Mathf.Deg2Rad * degrees);
        }

        public void Move(Vector2 to)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Rect rect)
        {
            return Contains(rect.A) && Contains(rect.B) && Contains(rect.C) && Contains(rect.D);
        }

        public bool Overlaps(Rect rect)
        {
            return Contains(rect.A) ||
                   Contains(rect.B) ||
                   Contains(rect.C) ||
                   Contains(rect.D) ||
                   rect.Contains(A) ||
                   rect.Contains(B) ||
                   rect.Contains(C) ||
                   rect.Contains(D);
        }

        public void GetDistance(Rect from)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetRandomPointInsideRect()
        {
            float minX = Mathf.Min(A.x, B.x, C.x, D.x);
            float minY = Mathf.Min(A.y, B.y, C.y, D.y);

            float maxX = Mathf.Max(A.x, B.x, C.x, D.x);
            float maxY = Mathf.Max(A.y, B.y, C.y, D.y);

            return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        bool Contains(Vector2 point)
        {
            Vector2 ab = B - A;
            Vector2 am = point - A;
            Vector2 bc = C - B;
            Vector2 bm = point - B;
            float dotAbAm = Vector2.Dot(ab, am);
            float dotAbAb = Vector2.Dot(ab, ab);
            float dotBcBm = Vector2.Dot(bc, bm);
            float dotBcBc = Vector2.Dot(bc, bc);
            return 0 <= dotAbAm && dotAbAm <= dotAbAb && 0 <= dotBcBm && dotBcBm <= dotBcBc;
        }

        static Vector2 RotatePoint(Vector2 point, Vector3 center, float angleRad)
        {
            float x1 = point.x - center.x;
            float y1 = point.y - center.y;

            float newX = x1 * Mathf.Cos(angleRad) - y1 * Mathf.Sin(angleRad) + center.x;
            float newY = x1 * Mathf.Sin(angleRad) + y1 * Mathf.Cos(angleRad) + center.y;

            return new Vector2(newX, newY);
        }
    }
}
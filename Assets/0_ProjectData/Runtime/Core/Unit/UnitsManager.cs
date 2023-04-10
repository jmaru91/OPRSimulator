using System;
using System.Collections.Generic;

namespace OPR
{
    public class UnitsManager : IDisposable
    {
        readonly Dictionary<Player, List<Unit>> m_units = new();

        public UnitsManager()
        {
        }

        public void Dispose()
        {
        }

        void CreateUnits()
        {
            throw new NotImplementedException();
        }
    }
}
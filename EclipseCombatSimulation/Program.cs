using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Battle.ShipDefinition def = new Battle.ShipDefinition();
            def.m_numInterceptors = 1;

            Battle battle = new Battle(def, def);
            battle.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Battle
    {
        Random rnd = new Random();
        int m_numBattles = 100000;
        Fleet attackerFleet;
        Fleet defenderFleet;

        public class ShipDefinition
        {
            public List<Upgrade> m_interceptorUpgrades = new List<Upgrade>();
            public int m_numInterceptors = 0;
            public List<Upgrade> m_cruiserUpgrades = new List<Upgrade>();
            public int m_numCruisers = 0;
            public List<Upgrade> m_dreadnaughtUpgrades = new List<Upgrade>();
            public int m_numDreadnaughts = 0;
            public List<Upgrade> m_orbitalUpgrades = new List<Upgrade>();
            public int m_numOrbitals = 0;
            public int m_numAncients = 0;
            public int m_numCenterBases = 0;
        }

        public Battle(ShipDefinition attackerShips, ShipDefinition defenderShips)
        {
            attackerFleet = CreateFleet(attackerShips);
            defenderFleet = CreateFleet(defenderShips);
        }

        private Fleet CreateFleet(ShipDefinition ships)
        {
            Fleet fleet = new Fleet();
            for (int i = 0; i < ships.m_numInterceptors; i++)
            {
                Interceptor interceptor;
                if (ships.m_interceptorUpgrades.Count > 0)
                {
                    interceptor = new Interceptor(ships.m_interceptorUpgrades);
                }
                else
                {
                    interceptor = new Interceptor();
                }
                fleet.AddShip(interceptor);
            }

            for (int i = 0; i < ships.m_numCruisers; i++)
            {
                Cruiser cruiser;
                if (ships.m_cruiserUpgrades.Count > 0)
                {
                    cruiser = new Cruiser(ships.m_cruiserUpgrades);
                }
                else
                {
                    cruiser = new Cruiser();
                }
                fleet.AddShip(cruiser);
            }

            for (int i = 0; i < ships.m_numDreadnaughts; i++)
            {
                Dreadnaught dreadnaught;
                if (ships.m_dreadnaughtUpgrades.Count > 0)
                {
                    dreadnaught = new Dreadnaught(ships.m_dreadnaughtUpgrades);
                }
                else
                {
                    dreadnaught = new Dreadnaught();
                }
                fleet.AddShip(dreadnaught);
            }

            for (int i = 0; i < ships.m_numOrbitals; i++)
            {
                Orbital orbital;
                if (ships.m_orbitalUpgrades.Count > 0)
                {
                    orbital = new Orbital(ships.m_orbitalUpgrades);
                }
                else
                {
                    orbital = new Orbital();
                }
                fleet.AddShip(orbital);
            }

            for (int i = 0; i < ships.m_numAncients; i++)
            {
                Ancient ancient = new Ancient();
                fleet.AddShip(ancient);
            }

            for (int i = 0; i < ships.m_numCenterBases; i++)
            {
                CenterBase centerBase = new CenterBase();
                fleet.AddShip(centerBase);
            }

            return fleet;
        }

        public void Run()
        {
            int defenderWins = 0;
            int attackerWins = 0;

            for (int i = 0; i < m_numBattles; i++)
            {
                if (Combat(attackerFleet, defenderFleet))
                {
                    attackerWins++;
                }
                else
                {
                    defenderWins++;
                }

                attackerFleet.ResetBattle();
                defenderFleet.ResetBattle();
            }

            double winPercentage = attackerWins / (double)m_numBattles;
            Console.Write("Winning percentage = " + winPercentage.ToString());
        }

        public bool Combat(Fleet attackers, Fleet defenders)
        {
            while (!attackers.Destroyed() && !defenders.Destroyed())
            {
                if (attackers.GetCurrentInitiative() > defenders.GetCurrentInitiative())
                {
                    Ship ship = attackers.GetAttacker();
                    AttackFleet(ship, defenders);
                }
                else
                {
                    Ship ship = defenders.GetAttacker();
                    AttackFleet(ship, attackers);
                }

                if (defenders.Done() && attackers.Done())
                {
                    defenders.ResetTurn();
                    attackers.ResetTurn();
                }
            }

            if (defenders.Destroyed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AttackFleet(Ship ship, Fleet fleet)
        {
            for (int i = 0; i < ship.RedDice; i++)
            {
                if (fleet.DetermineDamage(4, DiceRoll(), ship.Computers))
                {
                    if (fleet.Destroyed())
                    {
                        return;
                    }
                }
            }
            for (int i = 0; i < ship.OrangeDice; i++)
            {
                if (fleet.DetermineDamage(2, DiceRoll(), ship.Computers))
                {
                    if (fleet.Destroyed())
                    {
                        return;
                    }
                }
            }
            for (int i = 0; i < ship.YellowDice; i++)
            {
                if (fleet.DetermineDamage(1, DiceRoll(), ship.Computers))
                {
                    if (fleet.Destroyed())
                    {
                        return;
                    }
                }
            }
        }

        private int DiceRoll()
        {
            return rnd.Next(1, 7);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Program
    {
        Random rnd = new Random();
        static void Main(string[] args)
        {
        }

        public double Combat(List<Ship> attackers, List<Ship> defenders, int iterations)
        {
            int attackerWins = 0;
            int defenderWins = 0;

            for (int i = 0; i < iterations; i++)
            {
                List<Ship> attackersActive = attackers.OrderByDescending(o=>o.Initiative).ToList();
                List<Ship> defendersActive = defenders.OrderByDescending(o=>o.Initiative).ToList();

                List<Ship> attackersDone = new List<Ship>();
                List<Ship> defendersDone = new List<Ship>();

                bool defenderTurn = true;
                while (attackersActive.Count + attackersDone.Count > 0 && defendersActive.Count + defendersDone.Count > 0)
                {
                    if (attackersActive.Count > 0 && defendersActive.Count > 0)
                    {
                        if (defendersActive[0].Initiative >= attackersActive[0].Initiative)
                        {
                            defenderTurn = true;
                        }
                        else
                        {
                            defenderTurn = false;
                        }
                    }
                    else if (attackersActive.Count > 0)
                    {
                        defenderTurn = false;
                    }
                    else if (defendersActive.Count > 0)
                    {
                        defenderTurn = true;
                    }
                    else
                    {
                    }

                    Ship currentShip;
                    if (defenderTurn)
                    {
                        currentShip = defendersActive[0];
                    }
                    else
                    {
                        currentShip = attackersActive[0];
                    }
                    currentShip.Status = Ship.ShipStatus.Done;

                    for (int j = 0; j < currentShip.RedDice; j++)
                    {
                        int roll = this.DiceRoll();

                        if (roll == 6)
                        {
                        }
                    }
                }

                if (attackersActive.Count + attackersDone.Count == 0)
                {
                    defenderWins++;
                }
                else
                {
                    attackerWins++;
                }
            }

            return attackerWins / iterations;
        }

        private void DetermineDamage(Ship ship, List<Ship> targets)
        {
        }

        private int DiceRoll()
        {
            return rnd.Next(1, 7);
        }
    }
}

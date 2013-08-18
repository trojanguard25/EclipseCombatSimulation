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
            List<Ship> attackerList = new List<Ship>();
            List<Ship> defenderList = new List<Ship>();

            attackerList.Add(new Interceptor());
            //attackerList.Add(new Interceptor());
            //attackerList.Add(new Interceptor());

            //defenderList.Add(new Ancient());
            defenderList.Add(new Interceptor());
            //defenderList.Add(new Interceptor());

            int defenseWins = 0;
            int offenseWins = 0;
            int numBattles = 100000;

            Program prog = new Program();

            Fleet fleet1 = new Fleet(attackerList);
            Fleet fleet2 = new Fleet(defenderList);

            for (int i = 0; i < numBattles; i++)
            {
                if (prog.Combat(fleet1, fleet2))
                {
                    offenseWins++;
                }
                else
                {
                    defenseWins++;
                }

                fleet1.ResetBattle();
                fleet2.ResetBattle();
            }

            double winPercentage = offenseWins / (double)numBattles;
            Console.Write("Winning percentage = " + winPercentage.ToString());

            winPercentage = offenseWins / 50;
        }

        public bool Combat(Fleet attackers, Fleet defenders)
        {
            while (!attackers.Destroyed() && !defenders.Destroyed())
            {
                if (attackers.GetCurrentInitiative() > defenders.GetCurrentInitiative())
                {
                    Ship ship = attackers.GetAttacker();
                    AttackFleet(ship, defenders);
                    //Console.WriteLine("Attacker ship attacks. Defender Fleet Status:");
                    //defenders.PrintStatus();
                }
                else
                {
                    Ship ship = defenders.GetAttacker();
                    AttackFleet(ship, attackers);
                    //Console.WriteLine("Defender ship attacks. Attacker Fleet Status:");
                    //attackers.PrintStatus();
                }

                if (defenders.Done() && attackers.Done())
                {
                    //Console.WriteLine("New Turn!!!");
                    //Console.WriteLine("Attacker Fleet Status:");
                    //attackers.PrintStatus();
                    //Console.WriteLine("Defender Fleet Status:");
                    //defenders.PrintStatus();

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

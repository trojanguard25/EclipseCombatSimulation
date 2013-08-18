using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Fleet
    {
        List<Ship> m_active = new List<Ship>();
        List<Ship> m_done = new List<Ship>();
        List<Ship> m_dead = new List<Ship>();

        int m_numShips = 0;
        public Fleet()
        {
        }

        public Fleet(List<Ship> ships)
        {
            m_active = ships;
            m_numShips = m_active.Count;
            SortByInitiative();
        }

        public void AddShip(Ship ship)
        {
            m_active.Add(ship);
            m_numShips++;
            SortByInitiative();
        }

        private void SortByInitiative()
        {
            m_active = m_active.OrderByDescending(o => o.Initiative).ToList();
        }

        public void ResetBattle()
        {
            m_active.AddRange(m_dead);
            m_dead.Clear();
            m_active.AddRange(m_done);
            m_done.Clear();

            foreach (Ship ship in m_active)
            {
                ship.Damage = 0;
                ship.Status = Ship.ShipStatus.Active;
            }

            SortByInitiative();
        }

        public bool Destroyed()
        {
            return (m_numShips == m_dead.Count);
        }

        public void ResetTurn()
        {
            m_active = m_done.OrderByDescending(o => o.Initiative).ToList();
            m_done.Clear();
        }

        public Ship GetAttacker()
        {
            if (m_active.Count > 0)
            {
                Ship retn = m_active[0];
                m_active.RemoveAt(0);
                retn.Status = Ship.ShipStatus.Done;
                m_done.Add(retn);
                return retn;
            }
            else
            {
                return null;
            }
        }

        public int GetCurrentInitiative()
        {
            if (m_active.Count > 0)
            {
                return m_active[0].Initiative;
            }
            else
            {
                return -1;
            }
        }

        public bool Done()
        {
            return m_active.Count == 0;
        }

        public bool DetermineDamage(int damage, int roll, int computer)
        {
            int shipSize = -1;
            bool destroyed = false;
            Ship hitShip = null;

            // automatic miss on a 1
            if (roll == 1)
                return false;

            foreach (Ship ship in m_active)
            {
                if (ship.DetermineHit(roll, computer))
                {
                    // we already have a destroyed ship, so this ship needs to be destroyed in order
                    // to update (if larger size).
                    if (destroyed)
                    {
                        if (ship.Damage + damage > ship.HullPoints)
                        {
                            if (ship.Slots > shipSize)
                            {
                                hitShip = ship;
                                shipSize = ship.Slots;
                            }
                        }
                    }
                    else
                    {
                        if (ship.Damage + damage > ship.HullPoints)
                        {
                            hitShip = ship;
                            shipSize = ship.Slots;
                            destroyed = true;
                        }
                        else
                        {
                            if (ship.Slots > shipSize)
                            {
                                hitShip = ship;
                                shipSize = ship.Slots;
                            }
                        }
                    }
                }
            }

            foreach (Ship ship in m_done)
            {
                if (ship.DetermineHit(roll, computer))
                {
                    // we already have a destroyed ship, so this ship needs to be destroyed in order
                    // to update (if larger size).
                    if (destroyed)
                    {
                        if (ship.Damage + damage > ship.HullPoints)
                        {
                            if (ship.Slots > shipSize)
                            {
                                hitShip = ship;
                                shipSize = ship.Slots;
                            }
                        }
                    }
                    else
                    {
                        if (ship.Damage + damage > ship.HullPoints)
                        {
                            hitShip = ship;
                            shipSize = ship.Slots;
                            destroyed = true;
                        }
                        else
                        {
                            if (ship.Slots > shipSize)
                            {
                                hitShip = ship;
                                shipSize = ship.Slots;
                            }
                        }
                    }
                }
            }

            if (hitShip != null)
            {
                hitShip.Damage += damage;
                if (hitShip.Destroyed())
                {
                    m_dead.Add(hitShip);
                }
            }

            if (destroyed)
            {
                m_active.RemoveAll(o => o.Destroyed());
                m_done.RemoveAll(o => o.Destroyed());
            }

            return destroyed;
        }

        public void PrintStatus()
        {
            Console.WriteLine("\tTotal: " + m_numShips + " Active: " + m_active.Count + " Done: " + m_done.Count + " Dead: " + m_dead.Count);
        }
    }
}

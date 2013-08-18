using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Ship
    {
        List<Upgrade> m_upgrades;

        public enum ShipStatus
        {
            Active,
            Done,
            Destroyed
        }

        ShipStatus m_status = ShipStatus.Active;

        internal ShipStatus Status
        {
            get { return m_status; }
            set { m_status = value; }
        }


        int m_Initiative = 0;

        public int Initiative
        {
            get { return m_Initiative; }
            set { m_Initiative = value; }
        }
        int m_HullPoints = 0;

        public int HullPoints
        {
            get { return m_HullPoints; }
            set { m_HullPoints = value; }
        }
        int m_YellowDice = 0;

        public int YellowDice
        {
            get { return m_YellowDice; }
            set { m_YellowDice = value; }
        }
        int m_OrangeDice = 0;

        public int OrangeDice
        {
            get { return m_OrangeDice; }
            set { m_OrangeDice = value; }
        }
        int m_RedDice = 0;

        public int RedDice
        {
            get { return m_RedDice; }
            set { m_RedDice = value; }
        }
        int m_Missles = 0;

        public int Missles
        {
            get { return m_Missles; }
            set { m_Missles = value; }
        }
        int m_Shields = 0;

        public int Shields
        {
            get { return m_Shields; }
            set { m_Shields = value; }
        }
        int m_Computers = 0;

        public int Computers
        {
            get { return m_Computers; }
            set { m_Computers = value; }
        }
        int m_Power = 0;

        public int Power
        {
            get { return m_Power; }
            set { m_Power = value; }
        }
        int m_Slots = 0;

        public int Slots
        {
            get { return m_Slots; }
            set { m_Slots = value; }
        }

        int m_Damage = 0;

        public int Damage
        {
            get { return m_Damage; }
            set { m_Damage = value; }
        }

        public Ship()
        {
        }

        public bool Valid()
        {
            bool slots = m_upgrades.Count <= m_Slots;
            int numDrives = 0;
            int numPowerSources = 0;
            foreach (Upgrade tile in m_upgrades)
            {
                if (tile.IsDrive())
                {
                    numDrives++;
                }

                if (tile.IsPowerSource())
                {
                    numPowerSources++;
                }
            }

            bool powerSources = numPowerSources == 1;
            bool drives = numDrives == 1;

            return slots && powerSources && drives;
        }

        public void AddUpgrade(Upgrade tile)
        {
            m_upgrades.Add(tile);
            this.Power += tile.Power;
            this.Computers += tile.Computers;
            this.HullPoints += tile.HullPoints;
            this.Initiative += tile.Initiative;
            this.Missles += tile.Missles;
            this.OrangeDice += tile.OrangeDice;
            this.RedDice += tile.RedDice;
            this.Shields += tile.Shields;
            this.YellowDice += tile.YellowDice;
        }

        public bool Destroyed()
        {
            return m_Damage > m_HullPoints;
        }
    }

    class Interceptor : Ship
    {
        public Interceptor()
        {
            Initiative = 2;
            Slots = 4;
            AddUpgrade(new NuclearSource());
            AddUpgrade(new NuclearDrive());
            AddUpgrade(new IonCannon());
        }

        public Interceptor(List<Upgrade> upgrades)
        {
            Initiative = 2;
            Slots = 4;
            foreach (Upgrade tile in upgrades)
            {
                AddUpgrade(tile);
            }
        }
    }

    class Cruiser : Ship
    {
        public Cruiser()
        {
            Initiative = 1;
            Slots = 6;
            AddUpgrade(new NuclearSource());
            AddUpgrade(new NuclearDrive());
            AddUpgrade(new IonCannon());
            AddUpgrade(new Hull());
            AddUpgrade(new ElectronComputer());
        }

        public Cruiser(List<Upgrade> upgrades)
        {
            Initiative = 1;
            Slots = 6;
            foreach (Upgrade tile in upgrades)
            {
                AddUpgrade(tile);
            }
        }
    }

    class Dreadnaught : Ship
    {
        public Dreadnaught()
        {
            Slots = 8;
            AddUpgrade(new NuclearSource());
            AddUpgrade(new NuclearDrive());
            AddUpgrade(new Hull());
            AddUpgrade(new Hull());
            AddUpgrade(new ElectronComputer());
            AddUpgrade(new IonCannon());
            AddUpgrade(new IonCannon());
        }

        public Dreadnaught(List<Upgrade> upgrades)
        {
            Slots = 8;
            foreach (Upgrade tile in upgrades)
            {
                AddUpgrade(tile);
            }
        }
    }

    class Orbital : Ship
    {
        public Orbital()
        {
            Initiative = 4;
            Power = 3;
            Slots = 5;
            AddUpgrade(new Hull());
            AddUpgrade(new Hull());
            AddUpgrade(new ElectronComputer());
            AddUpgrade(new IonCannon());
        }

        public Orbital(List<Upgrade> upgrades)
        {
            Initiative = 4;
            Power = 3;
            Slots = 4;
            foreach (Upgrade tile in upgrades)
            {
                AddUpgrade(tile);
            }
        }
    }

    class Ancient : Ship
    {
        public Ancient()
        {
            Initiative = 2;
            HullPoints = 1;
            Computers = 1;
            YellowDice = 2;
        }
    }

    class CenterBase : Ship
    {
        public CenterBase()
        {
            HullPoints = 7;
            YellowDice = 4;
            Computers = 1;
        }
    }
}

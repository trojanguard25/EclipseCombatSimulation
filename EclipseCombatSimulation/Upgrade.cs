using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipseCombatSimulation
{
    class Upgrade
    {
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

        int m_PowerCost = 0;

        public int PowerCost
        {
            get { return m_PowerCost; }
            set { m_PowerCost = value; }
        }

        int m_Drive = 0;

        public int Drive
        {
            get { return m_Drive; }
            set { m_Drive = value; }
        }


        public Upgrade()
        {
        }

        public bool IsPowerSource()
        {
            return m_Power > 0;
        }

        public bool IsDrive()
        {
            return m_Drive > 0;
        }
    }

    class IonCannon : Upgrade
    {
        public IonCannon()
        {
            YellowDice = 1;
            PowerCost = 1;
        }
    }

    class Hull : Upgrade
    {
        public Hull()
        {
            HullPoints = 1;
        }
    }

    class ElectronComputer : Upgrade
    {
        public ElectronComputer()
        {
            Computers = 1;
        }
    }

    class NuclearSource : Upgrade
    {
        public NuclearSource()
        {
            Power = 3;
        }
    }

    class NuclearDrive : Upgrade
    {
        public NuclearDrive()
        {
            Drive = 1;
            PowerCost = 1;
        }
    }

    class IonTurret : Upgrade
    {
        public IonTurret()
        {
            YellowDice = 2;
            PowerCost = 1;
        }
    }

    class AxionComputer : Upgrade
    {
        public AxionComputer()
        {
            Computers = 3;
        }
    }

    class FluxShield : Upgrade
    {
        public FluxShield()
        {
            Shields = 3;
            PowerCost = 2;
        }
    }

    class ConformalDrive : Upgrade
    {
        public ConformalDrive()
        {
            Drive = 4;
            Initiative = 2;
            PowerCost = 2;
        }
    }

    class ShardHull : Upgrade
    {
        public ShardHull()
        {
            HullPoints = 3;
        }
    }

    class HyperGridSource : Upgrade
    {
        public HyperGridSource()
        {
            Power = 11;
        }
    }

    class PlasmaCannon : Upgrade
    {
        public PlasmaCannon()
        {
            OrangeDice = 1;
            PowerCost = 2;
        }
    }
    
    class PlasmaMissle : Upgrade
    {
        public PlasmaMissle()
        {
            Missles = 2;
        }
    }

    class PositronComputer : Upgrade
    {
        public PositronComputer()
        {
            Computers = 2;
            Initiative = 1;
            PowerCost = 1;
        }
    }

    class GluonComputer : Upgrade
    {
        public GluonComputer()
        {
            Computers = 3;
            Initiative = 2;
            PowerCost = 2;
        }
    }

    class AntiMatterCannon : Upgrade
    {
        public AntiMatterCannon()
        {
            RedDice = 1;
            PowerCost = 4;
        }
    }

    class ImprovedHull : Upgrade
    {
        public ImprovedHull()
        {
            HullPoints = 2;
        }
    }

    class GaussShield : Upgrade
    {
        public GaussShield()
        {
            Shields = 1;
        }
    }

    class PhaseShield : Upgrade
    {
        public PhaseShield()
        {
            Shields = 2;
            PowerCost = 1;
        }
    }

    class FusionDrive : Upgrade
    {
        public FusionDrive()
        {
            Drive = 2;
            PowerCost = 2;
            Initiative = 2;
        }
    }

    class TachyonDrive : Upgrade
    {
        public TachyonDrive()
        {
            Drive = 3;
            Initiative = 3;
            PowerCost = 3;
        }
    }

    class FusionSource : Upgrade
    {
        public FusionSource()
        {
            Power = 6;
        }
    }

    class TachyonSource : Upgrade
    {
        public TachyonSource()
        {
            Power = 9;
        }
    }
}

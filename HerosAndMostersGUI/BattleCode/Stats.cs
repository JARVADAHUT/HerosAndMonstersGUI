using System;
using System.Collections.Generic;
using System.Linq;


namespace DesignPatterns___DC_Design
{
    public class Stats
    {

        
        Dictionary<StatsType, int> _stats;

        public Stats()
        {
            _stats = new Dictionary<StatsType, int>();
        }

        public Stats(Dictionary<StatsType, int> stats)
        {
            if (stats == null) throw new ArgumentNullException("stats");
            _stats = stats;
        }

        public void AugmentStat(StatsType stat, int magnitude)
        {
            lock (this)
            {
                int moddingStat = _stats[stat];
                moddingStat += magnitude;
                moddingStat = ValidateStat(stat, moddingStat);
                _stats[stat] = moddingStat;
            }
        }

        public void AddStat(StatsType stat, int value)
        {
            if(HasStat(stat))
                throw new ArgumentException("Already Contains the stat: " + stat);
            _stats.Add(stat,value);
            if(stat == StatsType.MaxHp)
                AddStat(StatsType.CurHp,value);
            if(stat == StatsType.MaxResources)
                AddStat(StatsType.CurResources, value);
        }

        public bool HasStat(StatsType stat)
        {
            lock (this)
            {
                return _stats.ContainsKey(stat);
            }
        }

        public int GetStat(StatsType stat)
        {
            if (!HasStat(stat))
                throw new ArgumentException("Stats does not contain stat: " + stat);
            return _stats[stat];
        }

        private int ValidateStat(StatsType stat, int magnitude)
        {
            if(!HasStat(stat))
                throw new ArgumentException("Stats does not contain stat: " + stat);
            switch (stat)
            {
                case (StatsType.CurHp):
                    if (magnitude > _stats[StatsType.MaxHp])
                    {
                        magnitude = _stats[StatsType.MaxHp];
                    }
                    break;
                case (StatsType.CurResources):
                    if (magnitude > _stats[StatsType.MaxResources])
                    {
                        magnitude = _stats[StatsType.MaxResources];
                    }
                    break;
            }
            if (magnitude < 0)
                magnitude = 0;
            return magnitude;
        }

        public override string ToString()
        {
            lock (this)
            {
                return _stats.Keys.Aggregate("", (current, s) => current + (s + ":  " + _stats[s] + "\n"));

            }
        }

        /*
        int _maxHP, _curHp;
        int _strength, _agility, _defense, _intelegence;


        public int MaxHP { set { _maxHP=value < 0 ? 0 : value; } get { return _maxHP; } }
        public int CurHP { 
            set {
                if (value < 0)
                    value = 0;
                if (value > this.MaxHP)
                    value = this.MaxHP;
                _curHp = value; 
            } get { 
                return _curHp; 
            } 
        }
        public int Str { set { _strength = value < 0 ? 0 : value; } get { return _strength; } }
        public int Agl { set { _agility = value < 0 ? 0 : value;} get { return _agility;} }
        public int Def { set { _defense = value < 0 ? 0 : value; } get { return _defense; } }
        public int Int { set { _intelegence = value < 0 ? 0 : value; } get { return _intelegence; } }


        public void AugmentCurHP(int augment)
        {
            this.CurHP += augment;


            if (this.CurHP < 0)
                this.CurHP = 0;
            if (this.CurHP > this.MaxHP)
                this.CurHP = this.MaxHP;
        }


        public void AugmentMaxHP(int augment)
        {
            this.MaxHP += augment;


            if (this.MaxHP < 0)
                this.MaxHP = 0;
        }


        public void AugmentStr(int augment)
        {
            this.Str += augment;


            if (this.Str < 0)
                this.Str = 0;
        }


        public void AugmentDef(int augment)
        {
            this.Def += augment;


            if (this.Def < 0)
                this.Def = 0;
        }


        public void AugmentInt(int augment)
        {
            this.Int += augment;


            if (this.Int < 0)
                this.Int = 0;
        }


        public void AugmentAgl(int augment)
        {
            this.Agl += augment;


            if (this.Agl < 0)
                this.Agl = 0;
        }
         * 
         */
    }
}


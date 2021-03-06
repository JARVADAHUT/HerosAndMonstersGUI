﻿using System;
using System.Collections.Generic;

namespace DesignPatterns___DC_Design
{
    public class Target : IEnumerable<DungeonCharacter>
    {
        private List<DungeonCharacter> _targets;

        public DungeonCharacter this[int i]
        {
            get
            {
                return _targets[i];
            }
            set
            {
                _targets[i] = value;
            }
        }

        public Target()
        {
            _targets = new List<DungeonCharacter>();
        }

        public Target(params DungeonCharacter[] characters)
        {
            _targets = new List<DungeonCharacter>(characters);
        }

        public Target(List<DungeonCharacter> characters)
        {
            _targets = new List<DungeonCharacter>(characters);
        }

        public int Count()
        {
            return _targets.Count;
        }
        
        public void AddTarget(DungeonCharacter target)
        {
            this._targets.Add(target);
        }

        public void RemoveTarget(DungeonCharacter target)
        {
            this._targets.Remove(target);
        }

        public IEnumerator<DungeonCharacter> GetEnumerator()
        {
            return this._targets.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

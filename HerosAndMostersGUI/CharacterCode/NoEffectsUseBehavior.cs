using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    class NoEffectsUseBehavior : IUseItemBehavior
    {
        public void UseItem(GenericItems item, Target targets)
        {
        }
    }
}

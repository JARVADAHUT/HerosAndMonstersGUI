using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class InventoryContents <T>
    {
        private List<T> _myContents;

        public InventoryContents()
        {
            _myContents = new List<T>();
        }

        public void Add(T g)
        {
            _myContents.Add(g);
        }

        public void Add(List<T> theG)
        {
            foreach (T g in theG)
                _myContents.Add(g);
        }

        public List<T> GetContents()
        {
            return _myContents;
        }

    }
}

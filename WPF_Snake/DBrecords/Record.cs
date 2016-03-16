using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Snake
{
    class Record
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _rank;

        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private int _result;

        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }
        
        
        
        
    }
}

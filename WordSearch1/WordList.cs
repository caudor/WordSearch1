using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch1
{
    public class WordList
    {
        //public string TheWord { get; private set; }
        private List<string> _buildlist = new List<string>();  //init list

        public List<string> Getwords()
        {
            _buildlist.Add("CHRIS");
            _buildlist.Add("FRANK");
            _buildlist.Add("CALEB");
            _buildlist.Add("NANCY");
            _buildlist.Add("NATHAN");
            _buildlist.Add("KYLE");
            _buildlist.Add("DEACON");
            return _buildlist;
        }
    }
}

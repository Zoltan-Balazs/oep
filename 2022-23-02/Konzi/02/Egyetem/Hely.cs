using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyetem
{
    internal class Hely
    {
        public string terem;
        public int max;
        public List<Hallgato> hallgatok = new List<Hallgato>();

        public Hely(string terem, int max)
        {
            this.terem = terem;
            this.max = max;
        }
    }
}

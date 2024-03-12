using System;
using System.Collections.Generic;
using System.Text;

namespace Hunting
{
    class Trophy
    {
        public readonly Animal animal;
        public readonly string place;
        public readonly string date;
        public Trophy(Animal animal, string place, string date) { this.animal = animal; this.place = place; this.date = date; }

    }
}

using System;
using System.Collections.Generic;

namespace Garden
{
    class Garden
    {
        private List<Parcel> parcels;

        public Garden(int n)
        {
            parcels = new List<Parcel>();
            for (int i = 0; i < n; ++i)
            {
                parcels.Add(new Parcel());
            }
        }

        public class ParcelOutOfRangeException : Exception { }
        public void Harvest(int where)
        {
            if (where < 1 || parcels.Count < where)
            {
                throw new ParcelOutOfRangeException();
            }
            parcels[where - 1].Harvest();
        }

        public void Plant(int where, PlantType what, int month)
        {
            if (where < 1 || parcels.Count < where)
            {
                throw new ParcelOutOfRangeException();
            }
            parcels[where - 1].Plant(what, month);
        }

        public List<int> CanHarvest(int month)
        {
            List<int> harvestableParcels = new List<int>();
            for (int i = 0; i < parcels.Count; ++i)
            {
                if (parcels[i].HasRipened(month))
                {
                    harvestableParcels.Add(i + 1);
                }
            }

            return harvestableParcels;
        }
    }
}

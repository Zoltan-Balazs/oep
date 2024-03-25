using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using static Garden.Garden;

namespace Garden
{
    class Garden
    {
        public class GardenMustHaveParcelException : Exception { };

        public class ParcelNumberErrorException : Exception { };

        private readonly List<Parcel> parcels;
        public Parcel this[int i]
        {
            get
            {
                if (i < 0 || i >= parcels.Count)
                    throw new ParcelNumberErrorException();
                return parcels[i];
            }
        }

        public Garden(int n)
        {
            if (n <= 0)
                throw new GardenMustHaveParcelException();
            ;
            parcels = new List<Parcel>();
            for (int i = 0; i < n; ++i)
                parcels.Add(new Parcel());
        }

        public void Plant(int where, PlantType what, int month)
        {
            if (where < 1 || where > parcels.Count)
                throw new ParcelNumberErrorException();
            parcels[where - 1].Plant(what, month);
        }

        public List<int> CanHarvest(int month)
        {
            List<int> result = new();
            for (int i = 0; i < parcels.Count; ++i)
            {
                if (parcels[i].HasRipened(month))
                    result.Add(i + 1);
            }
            return result;
        }

        public void Harvest(int where)
        {
            if (where < 1 || where > parcels.Count)
                throw new ParcelNumberErrorException();
            parcels[where - 1].Harvest();
        }
    }
}

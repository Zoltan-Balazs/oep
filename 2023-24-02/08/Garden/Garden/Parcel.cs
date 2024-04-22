using System;

namespace Garden
{
    class Parcel
    {
        public PlantType Content { get; private set; }
        public int PlantingDate { get; private set; }

        public Parcel()
        {
            Content = null;
            PlantingDate = -1;
        }

        public class AlreadyPlantedException : Exception { }
        public void Plant(PlantType plant, int month)
        {
            if (null != Content)
            {
                throw new AlreadyPlantedException();
            }

            Content = plant;
            PlantingDate = month;
        }

        public bool HasRipened(int month)
        {
            return null != Content &&
                   Content.IsVegetable() &&
                   month - PlantingDate >= Content.ripeningTime;
        }

        public void Harvest()
        {
            Content = null;
        }
    }
}

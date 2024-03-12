namespace Garden
{
    class Parcel
    {
        public int PlantingDate { get; private set; }
        public PlantType Content { get; private set; }
        public Parcel() { Content = null; PlantingDate = 0; }
        public void Plant(PlantType plant, int month) 
        {
            if (null == Content) { Content = plant; PlantingDate = month; }
        }
        public bool HasRipened(int month)
        {
            return null != Content && Content.IsVegetable()        // ReferenceEquals(plant.GetType(), typeof(Vegetable)) 
                    && month - PlantingDate == Content.ripeningTime;
        }
        public void Harvest() { Content = null; }
    }
}

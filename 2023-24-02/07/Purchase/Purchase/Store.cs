namespace Purchase
{
    class Store
    {
        public Department foods;
        public Department technical;

        public Store(string foodsFileName, string technicalFileName)
        {
            foods = new Department(foodsFileName);
            technical = new Department(technicalFileName);
        }
    }
}

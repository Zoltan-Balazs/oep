namespace Purchase
{
    class Store
    {
        public Department foods;
        public Department technical;

        public Store(string fname, string tname)
        {
            foods = new Department(fname);
            technical = new Department(tname);
        }
    }
}

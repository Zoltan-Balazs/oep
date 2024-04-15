namespace Garden
{
    abstract class PlantType { }

    abstract class Vegetable : PlantType { }

    abstract class Flower : PlantType { }

    class Potato : Vegetable { }

    class Pea : Vegetable { }

    class Onion : Vegetable { }

    class Rose : Flower { }

    class Carnation : Flower { }

    class Tulip : Flower { }
}

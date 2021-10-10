namespace Lab9
{
    public class Animal
    {
        public string name ;

        public Animal(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
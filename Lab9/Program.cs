using System;

namespace Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DynamicList<Animal> list = new DynamicList<Animal>();

            var dambo = new Animal("elephant");
            list.Add(new Animal("cat"));
            list.Add(dambo);
            list.Add(new Animal("dog"));
            list.Add(new Animal("fox"));
            list.Add(dambo);
            
            Console.WriteLine(list.Count);
            Console.WriteLine(list.ToString());
            Console.WriteLine(list[1]);
            
            
            list.Remove(dambo);
            
            Console.WriteLine(list.ToString());
            
            list.RemoveAt(2);
            
            Console.WriteLine(list.ToString());
            
            //Console.WriteLine(list[1]);
            
            
        }
    }
}
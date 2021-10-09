using System;

namespace SingleTon
{
    public class Singleton
    {
        public Singleton()
        {

        }
        private static readonly object ThreadSafety = new object();
        private static Singleton instance = null;
        private string Name { get; set; } = "";
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (ThreadSafety)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                            instance.Name = "Nicat";
                        }
                    }
                }
                return instance;
            }
        }
        public override string ToString()
        {
            return Instance.Name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1= Singleton.Instance;
            Singleton singleton2= Singleton.Instance;

            Console.WriteLine(singleton1);
            Console.WriteLine(singleton2);
        }
    }
}

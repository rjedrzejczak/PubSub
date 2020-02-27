using System;

namespace PubSubDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Publisher pub1 = new Publisher();
            pub1.Name = "Pub1";
            
            Subscriber sub1 = new Subscriber();
            Subscriber sub2 = new Subscriber();
            Subscriber sub3 = new Subscriber();
            
            sub1.Subscribe(pub1);
            sub2.Subscribe(pub1);
            sub3.Subscribe(pub1);
            
            pub1.Notify("This is first Message");
            sub2.UnSubscribe(pub1);
            pub1.Notify("This message will not show up for Sub2");
        }
    }
}
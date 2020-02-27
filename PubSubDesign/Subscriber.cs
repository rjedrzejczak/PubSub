using System;
using System.Runtime.ConstrainedExecution;

namespace PubSubDesign
{
    public class Subscriber
    {
        public void Subscribe(Publisher pub)
        {
            pub.MyEvent += Update;
        }

        public void UnSubscribe(Publisher pub)
        {
            pub.MyEvent -= Update;
        }

        public void Update(object sender, EventArguments args)
        {
            Publisher pub = (Publisher) sender;
            Console.WriteLine(pub.Name + " sent a message" + args.Message);
        }
    }
}
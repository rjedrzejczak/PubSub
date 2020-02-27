using System;

namespace PubSubDesign
{
    public class Publisher
    {
        public string Name { get; set; }
        public event EventHandler<EventArguments> MyEvent;

        public void Notify(string message)
        {
            EventArguments args = new EventArguments(message);

            if (MyEvent != null)
            {
                MyEvent(this, args);
            }
        }
    }
}
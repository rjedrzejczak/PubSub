using System;

namespace PubSubDesign
{
    public class EventArguments : EventArgs
    {
        public string Message { get; }

        public EventArguments(string message)
        {
            Message = message;
        }
    }
}
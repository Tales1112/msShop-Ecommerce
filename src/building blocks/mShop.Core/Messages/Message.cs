using System;

namespace mShop.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; set; }
        public Guid AggregatedId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}

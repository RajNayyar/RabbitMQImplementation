using System;
namespace Config.services
{
    public class TopicConfig
    {
        public string routingKey = "nxtgen.*";
        public string Queue = "Flights";
        public string exchangeName = "NxtGenExchange";
    }
}


using System;
namespace Config.services
{
    public class FanoutConfig
    {
        public string routingKey = "";
        public string Queue = "FanoutQueue";
        public string exchangeName = "logs";
    }
}

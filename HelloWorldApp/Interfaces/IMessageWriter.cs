using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldApp.Interfaces
{
    interface IMessageWriter
    {
        Dictionary<string, string> getWriterConfiguration();
        bool initializeWriter();
        bool sendMessageToWriter(string strMessage);
        bool decommissionWriter();
    }
}

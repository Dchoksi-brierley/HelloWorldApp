using HelloWorldApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldApp.Writers
{
    class consoleWriter : IMessageWriter
    {
        public bool decommissionWriter()
        {
            //not required for Console output.
            return true;
        }

        public Dictionary<string, string> getWriterConfiguration()
        {
            //not required for Console output.
            return null;
        }

        public bool initializeWriter()
        {
            //not required for Console output.
            return true;
        }

        public bool sendMessageToWriter(string strMessage)
        {
            Console.WriteLine(strMessage);
            Console.ReadKey();
            return true;
        }
    }
}

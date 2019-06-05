using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Ex3.Models
{
    public class MyModel
    {

        private TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;
        private Random rnd;
        private bool flagDebug = false;
        private static MyModel s_instace = null;

        public static MyModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new MyModel();
                }
                return s_instace;
            }
        }

        public string Ip { get; set; } = "";
        public string Port { get; set; } = "";

        private MyModel()
        {
            if (flagDebug)
            {
                rnd = new Random();
            }
        }

        public void ConnectToSimulator(string ip, int port)
        {
            if (!flagDebug)
            {
                if (ip != Ip || port.ToString() != Port)
                {
                    DisconnectFromSimulator();
                    Ip = ip;
                    Port = port.ToString();
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port));
                    client = new TcpClient();
                    client.Connect(ep);
                    writer = new StreamWriter(client.GetStream());
                    reader = new StreamReader(client.GetStream());
                    Debug.WriteLine("Connection established");
                }

            }
        }

        public string ReceiveCoordinates()
        {
            if (flagDebug)
            {
                int lon = rnd.Next(-180, 180);
                int lat = rnd.Next(-90, 90);
                return lon + "," + lat;
            }
            string concatenatedValues = string.Join(",", ReceiveValue("Lon"), ReceiveValue("Lat"));
            return concatenatedValues;

        }

        public string GetNumOfValues(string filename)
        {
            string path = HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, filename));
            int lineCount = File.ReadLines(path).Count();
            return lineCount.ToString();
        }

        public void DisconnectFromSimulator()
        {
            if (!flagDebug && Ip != "" && Port != "")
            {
                writer.Close();
                reader.Close();
                client.Close();
            }
        }

        public void Send(string message)
        {
            if (!flagDebug)
            {
                if (writer != null)
                {
                    writer.WriteLine(message);
                    Debug.WriteLine("the command: " + message + " was delivered successfully");
                    //forcing the writer to send the message immediately
                    writer.Flush();
                }
                else
                {
                    Debug.WriteLine("The channel hasn't been established");
                }
            }
        }

        public string ReceiveValue(string value)
        {
            if (flagDebug)
            {
                return rnd.Next(-90, 90).ToString();
            }

            string message = "";
            if (value == "Lon")
            {
                message = "get /position/longitude-deg";
            }
            else if (value == "Lat")
            {
                message = "get /position/latitude-deg";
            }
            else if (value == "Throttle")
            {
                message = "get /controls/engines/current-engine/throttle";
            }
            else if (value == "Rudder")
            {
                message = "get /controls/flight/rudder";
            }
            Send(message);
            string response= reader.ReadLine();
            string[] splittedValues =response.Split('\'');
            return splittedValues[1];
        }
        
        public const string SCENARIO_FILE = "~/App_Data/{0}.txt";           // The Path of the Secnario

        public void WriteData(string name, string line)
        {
            string path = HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, name));

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path,true))
            {
                file.WriteLine(line);

            }
        }

        
        public string LoadValues(string name, int lineIndex)
        {
            string path = HttpContext.Current.Server.MapPath(String.Format(SCENARIO_FILE, name));

            return File.ReadLines(path).Skip(lineIndex - 1).FirstOrDefault();


        }

        public string AcquireValues()
        {
            string concatenatedValues=string.Join(",", ReceiveValue("Lon"), ReceiveValue("Lat"), ReceiveValue("Throttle"), ReceiveValue("Rudder"));
            return concatenatedValues;

        }
        public string SaveValues(string filename)
        {
            string values = AcquireValues();
            WriteData(filename, values);
            return values;
        }

    }
}
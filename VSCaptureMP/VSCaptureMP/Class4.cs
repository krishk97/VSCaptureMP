using System;
using System.Linq; 
using System.IO.Ports;

namespace VSCaptureMP
{
    public class Arduino
    {
        SerialPort port;
        public string name; 
        public int baud; 

        public Arduino()
        {
            if (port==null)
            {
                Console.WriteLine("Connect to Arduino...");
                Console.WriteLine(); 
                Console.WriteLine("Available ports:");

                if (SerialPort.GetPortNames().Count() >= 0)
                {
                    foreach (string p in SerialPort.GetPortNames())
                    {
                        Console.WriteLine(p);
                    }
                }
                else
                {
                    Console.WriteLine("No Ports available, press any key to exit.");
                    Console.ReadLine();
                    // Quit
                    return;
                }
                Console.WriteLine("Port Name:");
                name = Console.ReadLine();
                Console.WriteLine(" ");
                Console.WriteLine("Baud rate:");
                baud = GetBaudRate();

                Console.WriteLine(" ");

                port = new SerialPort(name, baud); //Set your board COM
                Console.WriteLine(""); 

                //port.Open();
                //port.WriteLine("Connected to C# console app..."); 
            }
        }

        private static int GetBaudRate()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid integer.  Please try again:");
                return GetBaudRate();
            }
        }

        public void writeString(string message)
        {
            port.WriteLine(message); 
        }
    }
}

using System;
using System.IO.Ports;
using System.Linq;

namespace IAdataReader
{
    class Program
    {
        // Create the serial port with basic settings 
        private SerialPort port;
        [STAThread]
        static void Main(string[] args)
        {
            // Instatiate this 
            SerialPortProgram();
        }

        private static void SerialPortProgram()
        {
            try
            {
                Console.WriteLine("Incoming Data:");
                // Attach a method to be called when there
                // is data waiting in the port's buffer pr
                Program prog = new Program();
                var x = SerialPort.GetPortNames().ToList();
                if (x.Any())
                {
                    var t = x.First(); 
                    prog.port = new SerialPort(x, 9600);
                    prog.port.DataReceived += new SerialDataReceivedEventHandler(prog.port_DataReceived);

                    // Begin communications 
                    prog.port.Open();
                    // Enter an application loop to keep this thread alive 
                    while (x != null)
                    {

                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                Console.WriteLine("\nToque cualquier tecla para terminar...");
                Console.Read();
            }
        }


        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine(port.ReadExisting());
        }
    }
}

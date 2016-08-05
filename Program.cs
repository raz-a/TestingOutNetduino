using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace TestingOutNetduino
{
    public class Program
    {
        private static bool toggleEnabled = false;

        public static void Main()
        {
            // Init Ports
            var ledPort = new OutputPort(Pins.ONBOARD_LED, false);
            var buttonPort = new InterruptPort(Pins.ONBOARD_BTN, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeHigh);

            buttonPort.OnInterrupt += ButtonPort_OnInterrupt;

            while (true)
            {
                if(toggleEnabled)
                {
                    ledPort.Write(!ledPort.Read());
                    Thread.Sleep(500);
                }
            }
        }

        private static void ButtonPort_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            toggleEnabled = !toggleEnabled;
        }
    }
}

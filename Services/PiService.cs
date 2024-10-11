using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;

namespace RaspApi.Services
{
    public class PiService
    {
        private int _ledPin = 18;

        public void EnableLED()
        {
            using (var controller = new GpioController())
            {
                controller.OpenPin(_ledPin, PinMode.Output);
                controller.Write(_ledPin, PinValue.High);
            }
        }

        public void DisableLED()
        {
            using (var controller = new GpioController())
            {
                controller.OpenPin(_ledPin, PinMode.Output);
                controller.Write(_ledPin, PinValue.Low);
            }
        }

    }
}

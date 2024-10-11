using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;

namespace RaspApi.Services
{
    public class PiService
    {
        public bool LEDOn { get; set; }

        private int _ledPin = 18;

        public PiService()
        {
        }


        //public void ToggleLED()
        //{
        //    using var controller = new GpioController();
        //    controller.OpenPin(_ledPin, PinMode.Output);
        //    controller.Write(_ledPin, ((LEDOn) ? PinValue.High : PinValue.Low));
        //    LEDOn = !LEDOn;
        //}

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

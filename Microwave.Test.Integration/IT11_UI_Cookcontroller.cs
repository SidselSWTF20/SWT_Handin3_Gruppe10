using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;

namespace Microwave.Test.Integration
{
    [TestFixture]
    class IT11_UI_Cookcontroller
    {
        private UserInterface _sut;
        private CookController _cookcontroller;
        private Door _door;
        private Button _button;
        private Light _light;
        private PowerTube _powertube;
        private Timer _timer;
        private Display _display;
        private Output _output; 

        [SetUp]

        public void SetUp()
        {
            _sut = new UserInterface(_button, _door, _display, _light, _cookcontroller);
            _cookcontroller = new CookController(_timer, _display, _powertube);
            _door = new Door();
            _button = new Button();
            _light = new Light(_output);
            _powertube = new PowerTube(_output);
            _timer = new Timer();
            _display = new Display(_output);
            _output = new Output();
        }
    }
}

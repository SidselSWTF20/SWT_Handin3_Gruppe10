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
    class IT10_Cookcontroller_Timer
    {
        private CookController _sut;
        private PowerTube _powertube;
        private Timer _timer;
        private Display _display;
        private Output _output;

        [SetUp]

        public void SetUp()
        {
            _sut = new CookController(_timer, _display, _powertube);
            _powertube = new PowerTube(_output);
            _timer = new Timer();
            _display = new Display(_output);
            _output = new Output();
        }
    }
}

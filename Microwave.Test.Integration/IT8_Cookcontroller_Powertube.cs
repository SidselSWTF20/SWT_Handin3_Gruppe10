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
    class IT8_Cookcontroller_Powertube
    {
        private CookController _sut;
        private PowerTube _powertube;
        private Output _output;

        private ITimer _timer;
        private IDisplay _display; //dette skal være en rigtig klasse istedet for en stub

        [SetUp]

        public void Setup()
        {
            _timer = Substitute.For<ITimer>();
            _display = Substitute.For<IDisplay>();

            _sut = new CookController(_timer, _display, _powertube);
            _powertube = new PowerTube(_output);
            _output = new Output();
        }
    }
}

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
    class IT9_Cookcontroller_Display
    {
        private CookController _sut;
        private PowerTube _powertube; //skal være en stub
        /// </summary>
        private Display _display;
        private Output _output;

        private ITimer _timer;

        [SetUp]

        public void SetUp()
        {
            _timer = Substitute.For<ITimer>();

            _sut = new CookController(_timer, _display, _powertube);
            _powertube = new PowerTube(_output);
            _display = new Display(_output);
            _output = new Output();
        }
    }
}

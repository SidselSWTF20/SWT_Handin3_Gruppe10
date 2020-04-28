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
    class IT8_Cookcontroller_Display
    {
        private CookController _sut; //System under test
        private Display _display; //Modul implementeret med kode
        private Output _output; //Modul implementeret med kode

        private IPowerTube _powertube; //Stubbet modul
        private ITimer _timer; //Stubbet modul

        [SetUp]

        public void SetUp()
        {
            _timer = Substitute.For<ITimer>();
            _powertube = Substitute.For<IPowerTube>();

            _display = new Display(_output);
            _output = new Output();
            _sut = new CookController(_timer, _display, _powertube);

        }
    }
}


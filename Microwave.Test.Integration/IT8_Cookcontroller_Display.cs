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
        private IUserInterface _userinterface; //Stubbet modul

        [SetUp]

        public void SetUp()
        {
            _timer = Substitute.For<ITimer>();
            _powertube = Substitute.For<IPowerTube>();
            _userinterface = Substitute.For<IUserInterface>();

            _display = new Display(_output);
            _output = new Output();
            _sut = new CookController(_timer, _display, _powertube, _userinterface);

        }

        [Test]
        public void Cooking_TimerTick_DisplayCalled()
        {
            _sut.StartCooking(50, 60);

            _timer.TimeRemaining.Returns(115);
            _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);

            _display.Received().ShowTime(1, 55);
        }

        [Test]
        //vi skal have testet om display bliver kaldt korrekt. 
        //jeg slettede de tests med powertube, for det skal ikke testes.
        //man kan ikke bruge recieved på en "rigtig" kode, kun på substitutes - åbenbart..

        public void DisplayIsCalledCorrect()
        {
            _display.ShowTime(50, 60);

            _display.Received(1);
        }

    }
}


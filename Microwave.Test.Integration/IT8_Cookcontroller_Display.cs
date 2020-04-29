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

        //Tester om der smides exeption, når der ikke er noget event

        public void OnTimerTickNot_DoesThrow()
        {

            Assert.That(() => _sut.OnTimerTick(this, EventArgs.Empty), Throws.Exception);
        }

        [Test]
        //tester om der kommer korrekt output?? kan vi det?
        public void StartCooking_Correctoutput()
        {
            _sut.StartCooking(50, 60);


        }

        [Test]

        //Teste om der kaldes Ontimertick, ved startcooking. Det er i metoden Ontimertick, 
        //At der kaldes til display. Hvis man kigger i koden. (Og også i sekvensdiagrammet). 
        //Det er derfor den der skal testes.

        public void Ontimertick_DisplayCalledCorrect(string line)
        {
            _sut.StartCooking(60, 50);
            _timer.TimeRemaining.Returns(110);
            _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);


        }





        //[Test]
        //public void Cooking_TimerTick_DisplayCalled()
        //{
        //    _sut.StartCooking(50, 60);

        //    _timer.TimeRemaining.Returns(115);
        //    _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);

        //    _display.ShowTime(1, 55);
        //}



    } 
}



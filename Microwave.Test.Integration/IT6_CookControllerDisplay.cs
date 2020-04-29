using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using Timer = MicrowaveOvenClasses.Boundary.Timer;


namespace Microwave.Test.Integration
{
    [TestFixture]
    public class IT6_CookControllerDisplay
    {
        private CookController _sut;

        private IUserInterface _userinterface;
        private IDisplay _display;
        private IPowerTube _powertube;
        private ITimer _timer;

        private IOutput _output;

        [SetUp]
        public void setup()
        {
            _userinterface= Substitute.For<IUserInterface>();
            _powertube= Substitute.For<IPowerTube>();
            _timer= new Timer();
            _output= Substitute.For<IOutput>();

            _display= new Display(_output);
            _sut= new CookController(_timer, _display, _powertube);
            _sut.UI = _userinterface;
        }

        [TestCase(0, "00:00")]
        [TestCase(10, "00:10")]
        [TestCase(120, "02:00")]
        public void showTime_MinAndSec_OutputContainsCorrectMinAndSec(int time, string expected)
        {
            _sut.StartCooking(350, time);
            _sut.OnTimerTick(this, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(s => s.Contains((expected))));
        }


        [TestCase(10, "00:05")]
        [TestCase(120, "01:55")]
        [TestCase(5999, "99:54")]
        //Ved denne test blev det tydeligt, at der er en fejl i Timer
        public void ShowTime_MinAndSecAfter5Seconds_OutputContainsCorrectMinAndSec(int time, string expected)
        {
            _sut.StartCooking(350, time);
            _sut.OnTimerTick(this, EventArgs.Empty);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _output.Received().OutputLine(Arg.Is<string>(s => s.Contains((expected))));
        }

    }
}

    


        

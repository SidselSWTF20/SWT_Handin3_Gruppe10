using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NSubstitute;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace Microwave.Test.Integration
{
    [TestFixture]
     public class IT5_CookControllerTimer
    {
        private CookController _sut;
        private Timer _timer;

        private IDisplay _display;
        private IPowerTube _powertube;
        private IUserInterface _userinterface;
        private IOutput _output;

        [SetUp]
        public void SetUp()
        {
            _userinterface= Substitute.For<IUserInterface>();
            _output = Substitute.For<IOutput>();
            _display = Substitute.For<IDisplay>();
            _powertube = Substitute.For<IPowerTube>();


            _timer = new Timer(); 
            _sut = new CookController(_timer, _display, _powertube);
            _sut.UI = _userinterface;

        }
        [TestCase(1380, 22, 55)]
        [TestCase(2800, 45, 55)]
        [TestCase(800, 12, 55)]
        [TestCase(60, 0, 55)]
        [TestCase(30, 0, 25)]

        public void StartCooking_WaitingFiveSeconds_CheckIfTimeIsCorrect(int s1, int min, int sec)
        {
            _sut.StartCooking(400, s1);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _display.Received(1).ShowTime(min, sec);

        }

        [TestCase(4)]
        [TestCase(1)]
        public void StartCooking_WaitFiveSeconds_TimeExpired_CheckTurnOff_Powertube(int s1)
        {
            _sut.StartCooking(400, s1);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _powertube.Received(1).TurnOff();

        }


        [TestCase(10)]
        [TestCase(9)]
        [TestCase(6)]
        public void StartCooking_WaitFiveSeconds_TimeNotExpired_PTNotTurnOff(int s1)
        {
            _sut.StartCooking(400, s1);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _powertube.DidNotReceive().TurnOff();
        }

        [TestCase(4)]
        [TestCase(1)]
        public void StartCooking_WaitFiveSeconds_TimeExpired_UI_CookingDone(int s1)
        {
            _sut.StartCooking(400, s1);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _userinterface.Received(1).CookingIsDone();

        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(6)]
        public void StartCooking_WaitFiveSeconds_TimeNotExpired_UT_CookingNotDone(int s1)
        {
            _sut.StartCooking(400, s1);

            ManualResetEvent pause = new ManualResetEvent(false);
            pause.WaitOne(5100);

            _userinterface.DidNotReceive().CookingIsDone();
        }

    }
}
    

    

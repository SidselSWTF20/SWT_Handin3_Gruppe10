using System;
using System.Threading;
using MicrowaveOvenClasses.Interfaces;

namespace MicrowaveOvenClasses.Controllers
{
    public class CookController : ICookController
    {
        // Since there is a 2-way association, this cannot be set until the UI object has been created
        // It also demonstrates property dependency injection
        public IUserInterface UI { set; private get; }

        private bool isCooking = false;

        private IDisplay myDisplay;
        private IPowerTube myPowerTube;
        private ITimer myTimer;
        private Timer timer;
        private IDisplay display;
        private IPowerTube powertube;

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube,
            IUserInterface ui) : this(timer, display, powerTube)
        {
            UI = ui;
        }

        public CookController(
            ITimer timer,
            IDisplay display,
            IPowerTube powerTube)
        {
            myTimer = timer;
            myDisplay = display;
            myPowerTube = powerTube;

            timer.Expired += new EventHandler(OnTimerExpired);
            timer.TimerTick += new EventHandler(OnTimerTick);
        }

        public CookController(Timer timer, IDisplay display, IPowerTube powertube)
        {
            this.timer = timer;
            this.display = display;
            this.powertube = powertube;
        }

        public void StartCooking(int power, int time)
        {
            myPowerTube.TurnOn(power);
            myTimer.Start(time);
            isCooking = true;
        }

        public void Stop()
        {
            isCooking = false;
            myPowerTube.TurnOff();
            myTimer.Stop();
        }

        public void OnTimerExpired(object sender, EventArgs e)
        {
            if (isCooking)
            {
                myPowerTube.TurnOff();
                UI.CookingIsDone();
                isCooking = false;
            }
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            int remaining = myTimer.TimeRemaining;
            myDisplay.ShowTime(remaining/60, remaining % 60);
        }
    }
}
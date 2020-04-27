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
    class IT2_Button
    {
        private Button _sut;

        private Door _door;
        private UserInterface _userinterface;

        private ICookController _cookcontroller;
        private ILight _light;
        private IDisplay _display;

        public void SetUp()
        {
            _cookcontroller = Substitute.For<ICookController>();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();

            _sut = new Button();
            _door = new Door();
            _userinterface = new UserInterface(_sut, _door, _display, _light, _cookcontroller);
            //Igen skal der fyldes noget ind i UI

        }
    }
}

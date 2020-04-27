﻿using System;
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
    class IT4_UI_Display
    {
        private UserInterface _sut;
        private Display _display;
        private Light _light;
        private Door _door;
        private Button _button;

        private ICookController _cookcontroller;
        private IOutput _output;

        [SetUp]

        public void SetUp()
        {
            _cookcontroller = Substitute.For<ICookController>();
            _output = Substitute.For<IOutput>();

            _sut = new UserInterface(_button, _door, _display, _light, _cookcontroller);
            _button = new Button();
            _door = new Door();
            _display = new Display(_output);
            _light = new Light(_output);
        }
    }
}

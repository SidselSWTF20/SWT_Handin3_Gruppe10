using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using MicrowaveOvenClasses.Controllers;

namespace Microwave.Test.Integration
{
    [TestFixture]
    public class IT1_Door
    {
        //System under test:
        private Door _sut;

        //UI der skal være den "rigtige klasse"
        private UserInterface _userinterface;


        //Skal være stubs = altså substitutes 
        private ILight _light;
        private IDisplay _display;
        private ICookController _cookcontroller;

        [SetUp]
        public void SetUp()
        {
            //Substitutes
            _display = Substitute.For<IDisplay>();
            _cookcontroller = Substitute.For<ICookController>();
            _light = Substitute.For<ILight>();

            //Ny dør og nyt UI
            _sut = new Door();
            _userinterface = new UserInterface(new Button(), _sut, _display, _light, _cookcontroller);
            //Men hvorfor den laver rød streg, ved jeg ikke!


        }
    }
}

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
    class IT5_DisplayOutput
    {
        private Display _sut;
        private Output _output;


        [SetUp]

        public void SetUp()
        {
            _output = new Output();

            _sut = new Display(_output);

        }

        [Test]
        
        public void OutputIsCorrect_Time()
        {
            _sut.ShowTime(10, 50);
            
        }

        [Test]
        // vi skal have testet om output bliver kaldt ved både showtime og showpower
        // og det kan ikke være sådan her, for der er den ligeglad med om jeg ændre det i contains.
        public void OutputIsCorrect_Power()
        {
            _sut.ShowPower(60);
            _output.OutputLine(Arg.Is<string>(str => str.Contains("80")));


        }
    }
}

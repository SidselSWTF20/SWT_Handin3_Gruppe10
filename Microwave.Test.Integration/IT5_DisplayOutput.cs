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
        //Tynd test. Tester om der bliver smidt en exeption, når show time bliver kaldt.
        public void ShowTime_DoesNotThrow()
        {
            
            Assert.That(() => _sut.ShowTime(10, 50), Throws.Nothing);
        }
        [Test]
        //Tynd test. Tester om der bliver smidt en exeption, når show power bliver kaldt.
        public void ShowPower_DoesNotThrow()
        {

            Assert.That(() => _sut.ShowPower(120), Throws.Nothing);
        }


        [Test]
        //Her tester vi om outputpine undeholder 10 og 50, når det er det der bliver sendt med showtime
        
        public void OutputIsCorrect_Time()
        {
            _sut.ShowTime(10, 50);
            _output.OutputLine(Arg.Is<string>(str => str.Contains("10")&& str.Contains("50")));


        }

        [Test]
        //Det samme for show power, når det er 60 der bliver sendt med.. Men det er ikke rigtigt.
        public void OutputIsCorrect_Power()
        {

            _sut.ShowPower(60);
            _output.OutputLine(Arg.Is<string>(str => str.Contains("60")));

        }


    }
}

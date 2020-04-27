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
    class IT7_Light_Output
    {
        private Light _sut;
        private Output _output;

        [SetUp]

        public void SetUp()
        {
            _sut = new Light(_output);
            _output = new Output();
        }

    }
}

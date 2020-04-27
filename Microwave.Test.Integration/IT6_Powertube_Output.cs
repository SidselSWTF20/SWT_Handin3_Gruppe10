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
    class IT6_Powertube_Output
    {
        private PowerTube _sut;
        private Output _output;

        [SetUp]

        public void SetUp()
        {
            _sut = new PowerTube(_output);
            _output = new Output();
        }
    }
}

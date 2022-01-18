using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Tests
{
    [TestClass()]
    public class TemperatureTests
    {
        [TestMethod()]
        public void PlusNumberTest()
        {
            var temperature = new Temperature(3, MeasureType.F);
            temperature = temperature + 31f;
            Assert.AreEqual("34 F", temperature.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()
        {
            var temperature = new Temperature(3, MeasureType.F);
            temperature = temperature - 1.75f;
            Assert.AreEqual("1,25 F", temperature.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var temperature = new Temperature(3, MeasureType.C);
            temperature = temperature * 3;
            Assert.AreEqual("9 C", temperature.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var temperature = new Temperature(3, MeasureType.F);
            temperature = temperature / 3;
            Assert.AreEqual("1 F", temperature.Verbose());
        }

        [TestMethod()]
        public void CompareByNumberTest()
        {
            var temperature = new Temperature(3, MeasureType.K);
            bool compare = temperature % 3;
            Assert.AreEqual("True K", compare.ToString() + " K");
        }

        [TestMethod()]
        public void OutputTemperatureTest()
        {
            var temperature = new Temperature(3, MeasureType.Ra);
            Assert.AreEqual(Temperature.Output(temperature), "3 Ra");
        }

        [TestMethod()]
        public void CelsiusToAnyTestAnyToCelsius()
        {
            Temperature temperature;

            temperature = new Temperature(9/5 + 32, MeasureType.F);
            Assert.AreEqual("1 C", temperature.To(MeasureType.C).Verbose());

            temperature = new Temperature(274, MeasureType.K);
            Assert.AreEqual("1 C", temperature.To(MeasureType.C).Verbose());

            temperature = new Temperature(9/5 + 491.67f, MeasureType.Ra);
            Assert.AreEqual("1 C", temperature.To(MeasureType.C).Verbose());
        }

        [TestMethod()]
        public void CelsiusToAnyTest()
        {
            Temperature temperature;

            temperature = new Temperature(32, MeasureType.C);
            Assert.AreEqual("89,6 F", temperature.To(MeasureType.F).Verbose());

            temperature = new Temperature(1, MeasureType.C);
            Assert.AreEqual("274 K", temperature.To(MeasureType.K).Verbose());

            temperature = new Temperature(491.67f, MeasureType.C);
            Assert.AreEqual("1376,676 Ra", temperature.To(MeasureType.Ra).Verbose());
        }
    }
}
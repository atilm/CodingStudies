using System.Linq;
using FluentAssertions;
using LogicGates.FunctionalComponents;
using LogicGatesTests.TestHelpers;
using NUnit.Framework;

namespace LogicGatesTests.FunctionalComponents
{
    [TestFixture]
    public class AdderTests
    {
        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(1, 1, 0, 1)]
        public void HalfAdderTest(int a, int b, int sum, int carry)
        {
            var halfAdder = new HalfAdder();
            halfAdder.InputA.Set(a);
            halfAdder.InputB.Set(b);
            halfAdder.Sum.ShouldBe(sum);
            halfAdder.Carry.ShouldBe(carry);
        }

        [Test]
        [TestCase(0, 0, 0,0, 0)]
        [TestCase(0, 1, 0,1, 0)]
        [TestCase(1, 0, 0,1, 0)]
        [TestCase(1, 1, 0,0, 1)]
        [TestCase(0, 0, 1,1, 0)]
        [TestCase(0, 1, 1,0, 1)]
        [TestCase(1, 0, 1,0, 1)]
        [TestCase(1, 1, 1,1, 1)]
        public void FullAdderTest(int a, int b, int carryIn, int sum, int carryOut)
        {
            var fullAdder = new FullAdder();
            fullAdder.InputA.Set(a);
            fullAdder.InputB.Set(b);
            fullAdder.CarryIn.Set(carryIn);
            fullAdder.Sum.ShouldBe(sum);
            fullAdder.Carry.ShouldBe(carryOut);
        }

        [Test]
        [TestCase("0001", "0001", "0010", "0")]
        [TestCase("0101", "0011", "1000", "0")]
        [TestCase("1110", "0001", "1111", "0")]
        [TestCase("1111", "0001", "0000", "1")]
        public void NBitAdderTest(string a, string b, string expectedSum, string expectedCarry)
        {
            var adder = new NBitAdder(4);
            
            adder.SetInput(AdderInput.A, a.ToVoltageArray());
            adder.SetInput(AdderInput.B, b.ToVoltageArray());
            
            adder.OutputsShouldBe(expectedSum.ToVoltageArray());
            adder.CarryOut.Voltage.Should().Be(expectedCarry.ToVoltageArray().Single());
        }
    }
}
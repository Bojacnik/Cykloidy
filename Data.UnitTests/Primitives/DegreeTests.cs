using Data.Basic.Implementations;
using System;

namespace Data.UnitTests.Primitives
{
    public class DegreeTests
    {
        Degree first;
        Degree second;

        [SetUp]
        public void SetUp()
        {
            first = new Degree(30);
            second = new Degree(10);
        }

        [Test]
        public void SetDegree()
        {
            Degree test = new Degree();
            test.Set(359);

            test.Get().Should().Be(359);
        }
        [Test]
        public void SetDegreeAboveBoundsViaSet()
        {
            Degree test = new Degree();

            for (int i = 1; i <= 359; i++)
            {
                test.Set(360 * i + i);
                test.Get().Should().Be(i);
            }
        }
        [Test]
        public void SetDegreeBelowBoundsViaSet()
        {
            Degree test = new Degree();
            for (int i = -1; i <= -359; i--)
            {
                test.Set(0 - 360 * Math.Abs(i + 1) - i);
                test.Get().Should().Be(359 - i);
            }
        }

        [Test]
        public void ShouldAddDegrees()
        {
            Degree result = first + second;
            result.Get().Should().Be(first.Get() + second.Get());
        }
        [Test]
        public void ShouldSubtractDegrees()
        {
            Degree result = first - second;
            result.Get().Should().Be(first.Get() - second.Get());
        }
        [Test]
        public void ShouldMultiplyDegrees()
        {
            Degree result = first * second;
            result.Get().Should().Be(first.Get() * second.Get());
        }
        [Test]
        public void ShouldDivideDegrees()
        {
            Degree result = first / second;
            result.Get().Should().Be(first.Get() / second.Get());
        }

    }
}

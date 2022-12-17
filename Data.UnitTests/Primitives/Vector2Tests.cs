using Data.Basic.Implementations;

namespace Domain.UnitTests.Primitives
{
    public class Vector2Tests
    {
        Vector2 vector;
        Vector2 vector2;
        int x, y; //used to control Vector2 constructors
        int toVector; //used for adding, subtracting, multiplying and dividing vectors

        [SetUp]
        public void Setup()
        {
            vector = new Vector2(x, y);
            vector2 = new Vector2(10, 20);
            x = 9;
            y = 18;
            toVector = 5;
        }

        //Testing Vector2 constructor
        [Test]
        public void ShouldHaveCorrectValues()
        {
            vector.x.Should().Be(x);
            vector.y.Should().Be(y);
        }
        //TODO: Add testing for the other Vector2 constructors

        //Testig Vector2.Default getter
        [Test]
        public void ShouldHaveCorrectDefaultValue()
        {
            Vector2 result = Vector2.Default;
            result.x.Should().Be(0);
            result.y.Should().Be(0);
        }

        //Testing overloaded operators for two vectors
        [Test]
        public void ShouldAddVectorsCorrectly()
        {
            Vector2 result = vector + vector2;
            result.x.Should().Be(vector.x + vector2.x);
            result.y.Should().Be(vector.y + vector2.y);
        }
        [Test]
        public void ShouldSubtractVectorsCorrectly()
        {
            Vector2 result = vector - vector2;
            result.x.Should().Be(vector.x - vector2.x);
            result.y.Should().Be(vector.y - vector2.y);
        }
        [Test]
        public void ShouldMultiplyVectorsCorrectly()
        {
            Vector2 result = vector * vector2;
            result.x.Should().Be(vector.x * vector2.x);
            result.y.Should().Be(vector.y * vector2.y);
        }
        [Test]
        public void ShouldDivideVectorsCorrectly()
        {
            Vector2 result = vector / vector2;
            result.x.Should().Be(vector.x / vector2.x);
            result.y.Should().Be(vector.y / vector2.y);
        }
    }
}

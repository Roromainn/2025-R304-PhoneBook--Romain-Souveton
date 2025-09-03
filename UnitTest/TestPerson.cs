using LogicLayer;

namespace UnitTests
{
    public class TestPerson
    {
        private Person CreatePerson()
        {
            return new Person("doe", "john");
        }

        [Fact]
        public void TestFirstName()
        {
            Person p = CreatePerson();
            Assert.Equal("john", p.FirstName);
            p.FirstName = "bill";
            Assert.Equal("bill", p.FirstName);
        }

        [Fact]
        public void TestLastName()
        {
            Person p = CreatePerson();
            Assert.Equal("doe", p.LastName);
            p.LastName = "smith";
            Assert.Equal("smith", p.LastName);
        }
		
		[Fact]
        public void TestEmptyLastName()
        {
            Person p = CreatePerson();
            Assert.Throws<NameEmptyException>(() => p.LastName = "");
        }

        [Fact]
        public void TestAddress()
        {
            Person p = CreatePerson();
            String s = "7b, sesame street";
            p.Address = s;
            Assert.Equal(s, p.Address);
        }

        [Fact]
        public void TestPhone()
        {
            Person p = CreatePerson();
            string s = "03-80-81-82-83";
            p.Phone = s;
            Assert.Equal(s, p.Phone);
        }

        [Fact]
        public void TestIdentity()
        {
            Person p = CreatePerson();
            Assert.Equal("DOE John", p.Identity);	
        }
    }
}
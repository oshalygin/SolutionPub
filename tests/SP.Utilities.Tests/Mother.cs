using System.Collections.Generic;

namespace SP.Utilities.Tests
{
    public static class Mother
    {
        public static List<TestUserClass> ListOfUsersWithNonDistinctFirstNames => new List<TestUserClass>()
        {
            new TestUserClass() {FirstName = "Oleg", LastName = "Foo"},
            new TestUserClass() {FirstName = "Oleg", LastName = "Bar"},
            new TestUserClass() {FirstName = "Foo", LastName = "Barus"},
            new TestUserClass() {FirstName = "Derp", LastName = "Lord"},
            new TestUserClass() {FirstName = "Herp", LastName = "Son"}
        };

    }
}

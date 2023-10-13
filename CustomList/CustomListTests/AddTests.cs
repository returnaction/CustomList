using CustomList;

namespace CustomListTests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void Add_CountIncrementsAsItemAdded_CountEqualsOne()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();

            //Act
            names.Add("Bob");

            //Assert
            Assert.AreEqual(1, names.Count);
        }

        [TestMethod]
        public void Add_FirstItemAddedAtIndexZero_IndexZeroEqualsBob()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();

            //Act
            names.Add("Bob");

            //Assert
            Assert.AreEqual("Bob", names[0]);
        }

        [TestMethod]
        public void Add_SecondItemAddedAtIndexOne_IndexOneEqualsTom()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();

            //Act
            names.Add("Bob");
            names.Add("Tom");

            //Assert
            Assert.AreEqual("Tom", names[1]);
        }

        [TestMethod]
        public void Add_CapacityIncreasesWhenExceeded_CapacityEqualsEight()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();
            int capasityBeforeIncreasing = names.Capacity;
            int capasityAfterIncreasing;

            //Act
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");

            capasityAfterIncreasing = names.Capacity;

            //Assert
            Assert.AreEqual(8, names.Capacity);
        }

        [TestMethod]
        public void Add_WhenCapacityIncreasesOriginalItemsStayAtTheSamePosition_Index3EqualsBob()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();

            //Act
            names.Add("Tom");
            names.Add("Tos");
            names.Add("Tod");
            names.Add("Bob");
            names.Add("Tog");
            names.Add("Tot");
            //Assert
            Assert.AreEqual("Bob", names[3]);

        }

        [TestMethod]
        public void Add_CapacityIncreasingAfterListIsResized_CapacityEqualsEight()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 4 };

            //Act
            numbers.Add(5);

            //Assert
            Assert.AreEqual(8, numbers.Capacity);
        }
    }
}
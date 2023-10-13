using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void Zip_WhenZippingAnotherCustomListsOfIntegers_CountEqualsSix()
        {
            //Arrange
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 4, 5, 6 };

            //Act
            numbers1.Zip(numbers2);

            //Assert
            Assert.AreEqual(6, numbers1.Count);
        }

        [TestMethod]
        public void Zip_WhenZippingAnothercustomListifStrings_CountEqualsSix()
        {
            //Arrange
            CustomList<string> names = new CustomList<string> { "Bob", "Bill", "Brian" };
            CustomList<string> names2 = new CustomList<string> { "Tom", "Jhon", "Sam" };

            //Act
            names.Zip(names2);

            // Assert
            Assert.AreEqual(6, names.Count);
        }

        [TestMethod]
        public void Zip_WhenZippingIntegersFirstIndexOfListToZippedBeOnTheIndex1_ReturnsTrue()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int> { 1, 3, 5 };
            CustomList<int> numbers2 = new CustomList<int> { 2, 4, 6 };

            //Act
            numbers.Zip(numbers2);

            //Assert
            Assert.AreEqual(2, numbers[1]);
        }
    }


}

using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void Sort_SortItegersInAscendingOrder_FirstIndexEqualsOne()
        {
            //Arrage
            CustomList<int> unsortedNumbers = new CustomList<int> { 5, 3, 3, 2, 1 };
            CustomList<int> result;

            //Act
            result = unsortedNumbers.Sort(unsortedNumbers);

            //Assert
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void Sort_SortStringsInAscendingOrser_FirstIndexEqualsApple()
        {
            //arrange
            CustomList<string> unsortedList = new CustomList<string> { "Corn", "Horn", "Tomato", "Apple" };
            CustomList<string> result;

            //act
            result = unsortedList.Sort(unsortedList);

            //assert
            Assert.AreEqual("Apple", result[0]);
        }
    }
}

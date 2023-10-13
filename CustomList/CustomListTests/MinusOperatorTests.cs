using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class MinusOperatorTests
    {
        [TestMethod]
        public void MinusOperator_SubValuesInSecondFromFirstListFirstListIsLonger_ReturnsModifiedFirstList()
        {
            // Arrange
            CustomList<int> compareList = new CustomList<int> { 4 };
            CustomList<int> listOne = new CustomList<int> { 4, 2 };
            CustomList<int> listTwo = new CustomList<int> { 2 };

            // Act
            CustomList<int> result = listOne - listTwo;

            // Assert
            for (int i = 0; i < compareList.Count; i++)
            {
                Assert.AreEqual(compareList[i], result[i]);
            }
        }
        // shorter
        [TestMethod]
        public void MinusOperator_SubValuesInSecondFromFirstListFirstListIsShorter_ReturnsModifiedFirstList()
        {
            // Arrange
            CustomList<int> compareList = new CustomList<int> { 4 };
            CustomList<int> listOne = new CustomList<int> { 4, 2, 6 };
            CustomList<int> listTwo = new CustomList<int> { 2, 7, 8, 6 };

            // Act
            CustomList<int> result = listOne - listTwo;

            // Assert
            for (int i = 0; i < compareList.Count; i++)
            {
                Assert.AreEqual(compareList[i], result[i]);
            }
        }

        [TestMethod]
        public void MinusOperator_IsSecondListIsEmptyResultIsUnchanged_ReturnTrue()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            CustomList<int> numbers2 = new CustomList<int>();
            bool result = false;

            //Act 
            CustomList<int> numbers3 = numbers - numbers2;

            result = numbers.Count == numbers3.Count;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinusOperator_RemoveOnlyInstancesThatAreInList_ReturnTrue()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int> { 3, 3, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            bool result = false;

            //Act 
            // Can write better than this ... maybe change it later
            CustomList<int> numbers3 = numbers - numbers2;
            result = numbers3[0] == numbers3[1];

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinusOperator_RemovesItemsFromTheList_CountEqualsTree()
        {
            //Arrange
            CustomList<string> names1 = new CustomList<string> { "Bob", "Mike", "Tom", "Tim", "Bill" };
            CustomList<string> names2 = new CustomList<string> { "Tom", "Tim" };

            //Act 
            CustomList<string> result = names1 - names2;

            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}

using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class PlusOperatorTests
    {
        [TestMethod]
        public void PlusOperator_FirstListIsLongerThanSecondOne_ReturnTrue()
        {
            //Arrange
            CustomList<int> one = new CustomList<int> { 1, 2, 3 };
            CustomList<int> two = new CustomList<int> { 4, 5 };
            CustomList<int> three = one + two;
            bool result = false;

            //Act
            if (three[0] == one[0] && three[1] == one[1] && three[2] == one[2] && three[3] == two[0] && three[4] == two[1])
            {
                result = true;
            }

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PlusOperator_SecondListIsLongerThanTheFirstList_ReturnsListCountEqualsFive()
        {
            //Arrange
            CustomList<int> one = new CustomList<int> { 1, 2 };
            CustomList<int> two = new CustomList<int> { 3, 4, 5 };

            //Act
            CustomList<int> result = one + two;
            
            //Assert
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void PlusOperator_IfOneListisEmptyResultsUnchanged_ReturnTrue()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            CustomList<int> numbers2 = new CustomList<int>();
            bool result = false;

            //Act
            CustomList<int> numbers3 = numbers + numbers2;

            result = numbers.Count == numbers3.Count;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PlusOperator_CountIncreasesWhenAddigTwoLists_CountEqualsFive()
        {
            //Arrange
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 4, 4 };

            //Act
            CustomList<int> result = numbers1 + numbers2;

            //Assert
            Assert.AreEqual(5, result.Count);
        }



    }
}

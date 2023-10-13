using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToString_AListOfStringsReturnExpectedResult_ReturnTrue()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();
            names.Add("Bob");
            bool result = false;

            //Act
            result = names.ToString() == "Bob";

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_AListOfIntsReturnsExpectedResult_True()
        {
            //Arrange
            CustomList<int> numbers = new CustomList<int>();
            int number1 = 1;
            int number2 = 2;
            int number3 = 3;
            numbers.Add(number1);
            numbers.Add(number2);
            numbers.Add(number3);
            bool result = false;
            string numbersString = "";
            string numbersStringFromList = "";

            //Act
            numbersString = $"{number1}{number2}{number3}";
            numbersStringFromList = numbers.ToString();
            result = numbersString == numbersStringFromList;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_AnEmptyListReturnsAnEmptyString_ReturnTrue()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();
            string emptyString = "";
            bool result = false;

            //Act
            result = names.ToString() == "";

            //Assert
            Assert.IsTrue(result);
        }
    }
}

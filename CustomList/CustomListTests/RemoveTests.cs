using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void Remove_CountDecremeantingWhenItemAdded_ReturnTrue()
        {
            // Arange
            CustomList<string> names = new CustomList<string>();
            names.Add("Tom");
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");
            int countBeforeRemove = names.Count;
            int countAfterRemove;

            //Act
            names.Remove("Tom");
            countAfterRemove = names.Count;

            // Assert
            Assert.IsTrue(countBeforeRemove > countAfterRemove);
        }

        [TestMethod]
        public void Remove_WhenItemRemovedSuccesfuly_ReturnTrue()
        {
            // Arange
            CustomList<string> names = new CustomList<string>();
            names.Add("Tom");
            names.Add("Bob");
            names.Add("Tom");
            bool result = false;

            //Act
            result = names.Remove("Bob");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_CountDoesNotDecrementIfCouldNotRemoveItem_CountStaysTheSame()
        {
            // Arrange
            CustomList<string> names = new CustomList<string>();
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");
            int countBeforeRemoving = names.Count;

            //Act
            names.Remove("Tom");
            int countAfterRemoving = names.Count;

            // Assert
            Assert.AreEqual(3, names.Count);
        }

        [TestMethod]
        public void Remove_ItemsShiftBackwardsAfterRemovingOneItem_IndexOneEqualsIndexTwo()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();
            names.Add("Nikita");
            names.Add("Bob");
            names.Add("Tom");

            //Act
            names.Remove("Nikita");

            //Assert
            Assert.AreEqual(names[1], "Tom");
        }

        [TestMethod]
        public void Remove_RemoveOnlyFirstItemWithTheSameName_ReturnTrue()
        {
            //Arrange
            CustomList<string> names = new CustomList<string>();
            names.Add("Bob");
            names.Add("Bob");
            names.Add("Bob");
            bool result1 = false;

            //Act
            names.Remove("Bob");
            if (names[0] == "Bob" && names[1] == "Bob")
            {
                result1 = true;
            }

            //Assert
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void Remove_CouldNotRemoveItem_ReturnFalse()
        {
            // Arrange
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 4, 5 };
            bool results = true;

            //Act
            results = numbers.Remove(7);

            // Assert
            Assert.IsFalse(results);
        }
    }
}

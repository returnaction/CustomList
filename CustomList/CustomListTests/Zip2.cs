using CustomList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTests
{
    [TestClass]
    public class Zip2
    {
        [TestMethod]
        public void Zip2_blblblbl_blbllbb()
        {
            //arrange
            CustomList<int> compareList = new CustomList<int> { 1, 2, 3, 4, 5, 6 };
            CustomList<int> number1 = new CustomList<int> { 1, 3, 5 };
            CustomList<int> number2 = new CustomList<int> { 2, 4, 6 };

            //act
            CustomList<int> result = number1.Zip2(number2);

            //assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(compareList[i], result[i]);
            }
        }
    }
}

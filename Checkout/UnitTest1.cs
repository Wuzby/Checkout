namespace Checkout
{
    public class UnitTest1
    {
        [Fact]
        public void Scan_AddToTotalOneItem_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");

            //Assert
            Assert.Equal(50, main.GetTotalPrice());
        }


        [Fact]
        public void Scan_AddToTotalSeveralItemsUnique_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");
            main.Scan("B");
            main.Scan("C");
            main.Scan("D");

            var result = main.GetTotalPrice();

            //Assert
            Assert.Equal(115, result);
        }

        [Fact]
        public void Scan_AddToTotalSeveralItemsDuplicates_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");
            main.Scan("A");
            main.Scan("C");
            main.Scan("C");

            var result = main.GetTotalPrice();

            //Assert
            Assert.Equal(140, result);
        }

        [Fact]
        public void Scan_AddToTotalSeveralItemsDuplicates_ApplyDiscount_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");
            main.Scan("A");
            main.Scan("A");

            var result = main.GetTotalPrice();

            //Assert
            Assert.Equal(130, result);
        }

        [Fact]
        public void Scan_AddToTotalSeveralItemsDuplicates_ApplyDiscountForTwoItemsUnique_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");
            main.Scan("A");
            main.Scan("A");
            main.Scan("B");
            main.Scan("B");

            var result = main.GetTotalPrice();

            //Assert
            Assert.Equal(175, result);
        }

        [Fact]
        public void Scan_ItemNotPresent_Fail()
        {
            //Arrange
            Main main = new Main();
            string itemX = "X";

            //Act
            Action action = () => main.Scan(itemX);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
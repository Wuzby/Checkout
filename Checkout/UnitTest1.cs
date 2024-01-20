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

            //Assert
            Assert.Equal(115, main.GetTotalPrice());
        }
    }
}
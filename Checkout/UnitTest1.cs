namespace Checkout
{
    public class UnitTest1
    {
        [Fact]
        public void ScanItem_Success()
        {
            //Arrange
            Main main = new Main();

            //Act
            main.Scan("A");

            //Assert
            Assert.Equal(50, main.GetTotalPrice());
        }
    }
}
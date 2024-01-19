namespace Checkout
{
    public class UnitTest1
    {
        [Fact]
        public void Scan_AddToTotal_Success()
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
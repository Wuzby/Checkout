namespace Checkout
{
    public class UnitTest1
    {
        [Fact]
        public void ScanItem_Success()
        {
            //Arrange
            ICheckOut checkout = new Checkout();

            //Act
            checkout.Scan("A");

            //Assert
            Assert.Equal("A", checkout.GetTotalPrice());
        }
    }
}
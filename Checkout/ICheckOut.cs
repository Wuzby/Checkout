namespace Checkout
{
    internal interface ICheckOut
    {
        void CheckOut();
        int GetTotalPrice();
    }
}
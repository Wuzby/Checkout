namespace Checkout
{
    internal interface ICheckOut
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
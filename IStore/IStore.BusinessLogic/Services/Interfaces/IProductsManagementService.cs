using IStore.Domain;

namespace IStore.BusinessLogic.Services.Interfaces
{
    public interface IProductsManagementService
    {
        Product Add(string title, string description, double price, string image, int categoryId);
        Supplier GetAllSuppliersForProduct(int productId);
        void UploadImage(byte[] imageData);
    }
}

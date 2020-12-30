namespace IStore.BusinessLogic.Services.Interfaces
{
    public interface IAdministrationService
    {
        void SetDiscountOnCategory(int categoryId, int discountPercent);
    }
}

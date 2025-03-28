using KK.BusinessCards.Apps.BlazorServer.DataModels;

namespace KK.BusinessCards.Apps.BlazorServer.DataProviders
{
    public interface IBusinessCardDataProvider
    {
        List<BusinessCard> GetCardList();

        void CreateCard(BusinessCard businessCard);

        void UpdateCard(BusinessCard businessCard);

        void DeleteCard(string cardID);
    }
}

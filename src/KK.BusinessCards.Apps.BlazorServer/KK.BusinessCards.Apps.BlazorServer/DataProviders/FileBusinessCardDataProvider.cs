using KK.BusinessCards.Apps.BlazorServer.DataModels;
using Newtonsoft.Json;

namespace KK.BusinessCards.Apps.BlazorServer.DataProviders
{
    public class FileBusinessCardDataProvider : IBusinessCardDataProvider
    {
        private string _basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/BusinessCards/";

        private string _filename = "BusinessCards.json";

        private List<BusinessCard> _cardList = new List<BusinessCard>();

        public FileBusinessCardDataProvider()
        {
            if(!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            if (File.Exists(_basePath + _filename))
            {
                try
                {
                    string json = File.ReadAllText(_basePath + _filename);

                    List<BusinessCard> cards = JsonConvert.DeserializeObject<List<BusinessCard>>(json);

                    _cardList = cards;
                }
                catch
                { }
            }
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_cardList, Formatting.Indented);

            File.WriteAllText(_basePath + _filename, json);
        }

        public void CreateCard(BusinessCard businessCard)
        {
            _cardList.Add(businessCard);
            Save();
        }

        public void DeleteCard(string cardID)
        {
            int deleteIndex = -1;

            for (int counter = 0; counter < _cardList.Count; counter++)
            {
                if (_cardList[counter].GUID == cardID)
                {
                    deleteIndex = counter;
                    break;
                }
            }

            if(deleteIndex != -1)
            {
                _cardList.RemoveAt(deleteIndex);
                Save();
            }
        }

        public List<BusinessCard> GetCardList()
        {
            return _cardList;
        }

        public void UpdateCard(BusinessCard businessCard)
        {
            int updateIndex = -1;

            for (int counter = 0; counter < _cardList.Count; counter++)
            {
                if (_cardList[counter].GUID == businessCard.GUID)
                {
                    updateIndex = counter;
                    break;
                }
            }

            if (updateIndex != -1)
            {
                _cardList[updateIndex] = businessCard;
                Save();
            }
        }
    }
}

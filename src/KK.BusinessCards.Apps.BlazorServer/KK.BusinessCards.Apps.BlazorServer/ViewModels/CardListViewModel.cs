using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KK.BusinessCards.Apps.BlazorServer.DataModels;
using KK.BusinessCards.Apps.BlazorServer.DataProviders;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KK.BusinessCards.Apps.BlazorServer.ViewModels
{
    public class CardListViewModel : ObservableObject
    {
        private IBusinessCardDataProvider _dataProvider;

        public BusinessCardViewModel CardUnderEdit { get; private set; }

        public bool IsNewCard { get; set; }

        public CardListViewModel(IBusinessCardDataProvider businessCardDataProvider)
        {
            _dataProvider = businessCardDataProvider;
            InitializeCardList();

            if(CardList.Count > 0)
            {
                ExecuteSelectionChangedCommand(CardList[0].BusinessCard.GUID);
            }

            InitializeCommands();
        }

        private void InitializeCardList()
        {
            CardList = new ObservableCollection<BusinessCardViewModel>();

            List<BusinessCard> cards = _dataProvider.GetCardList();

            foreach(BusinessCard businessCard in cards)
            {
                CardList.Add(new BusinessCardViewModel(businessCard));
            }
        }

        private void InitializeCommands()
        {
            StartCreateCardCommand = new RelayCommand(ExecuteStartCreateCardCommand);
            DeleteCardCommand = new RelayCommand(ExecuteDeleteCardCommand);
            EditCardCommand = new RelayCommand(ExecuteEditCardCommand);
            SaveCardCommand = new RelayCommand(ExecuteSaveCardCommand);
            CancelEditCardCommand = new RelayCommand(ExecuteCancelEditCardCommand);
            SelectionChangedCommand = new RelayCommand<string>(ExecuteSelectionChangedCommand);
        }

        

        public bool ShowEditor
        {
            get 
            { 
                return CardUnderEdit != null; 
            }
            
        }

        public BusinessCardViewModel SelectedCard
        {
            get
            {
                BusinessCardViewModel result = null;
                
                foreach(BusinessCardViewModel cardViewModel in CardList)
                {
                    if(cardViewModel.IsSelected)
                    {
                        result = cardViewModel;
                        break;
                    }
                }

                return result;
            }
        }


        public ObservableCollection<BusinessCardViewModel> CardList { get; set; } = new ObservableCollection<BusinessCardViewModel>();

        public ICommand StartCreateCardCommand { get; private set; }

        public ICommand DeleteCardCommand { get; private set; }

        public ICommand EditCardCommand { get; private set; }

        public ICommand SaveCardCommand { get; private set; }

        public ICommand CancelEditCardCommand { get; private set; }

        public ICommand SelectionChangedCommand { get; private set; }

        private void ExecuteStartCreateCardCommand()
        {
            CardUnderEdit = new BusinessCardViewModel(new BusinessCard());
            IsNewCard = true;
            OnPropertyChanged("ShowEditor");
        }

        private void ExecuteCancelEditCardCommand()
        {
            CardUnderEdit = null;
            OnPropertyChanged("ShowEditor");
        }

        private void ExecuteSaveCardCommand()
        {
            if (CardUnderEdit != null)
            {
                if (IsNewCard)
                {
                    _dataProvider.CreateCard(CardUnderEdit.BusinessCard);
                    CardList.Add(new BusinessCardViewModel(CardUnderEdit.BusinessCard));
                    ExecuteSelectionChangedCommand(CardUnderEdit.BusinessCard.GUID);
                }
                else
                {
                    SelectedCard.BusinessCard = CardUnderEdit.BusinessCard;
                    _dataProvider.UpdateCard(CardUnderEdit.BusinessCard);
                }
                CardUnderEdit = null;
                OnPropertyChanged("ShowEditor");
            }
        }

        private void ExecuteEditCardCommand()
        {
            BusinessCardViewModel selectedCard = SelectedCard;

            if(selectedCard != null)
            {
                IsNewCard = false;
                CardUnderEdit = new BusinessCardViewModel(selectedCard.BusinessCard.Clone() as BusinessCard);
                OnPropertyChanged("ShowEditor");
            }
        }

        private void ExecuteDeleteCardCommand()
        {
            BusinessCardViewModel selectedCard = SelectedCard;

            if (selectedCard != null)
            {

                int deleteIndex = -1;

                _dataProvider.DeleteCard(selectedCard.BusinessCard.GUID);

                for (int count = 0; count < CardList.Count; count++)
                {
                    BusinessCardViewModel cardViewModel = CardList[count];
                    if (cardViewModel == selectedCard)
                    {
                        deleteIndex = count;
                    }
                }
                if (deleteIndex != -1)
                {
                    CardList.RemoveAt(deleteIndex);
                }


                if (CardList.Count > 0)
                {
                    ExecuteSelectionChangedCommand(CardList[0].BusinessCard.GUID);
                }
                OnPropertyChanged();
            }
        }

        private void ExecuteSelectionChangedCommand(string? guid)
        {
            if(guid != null)
            {
                foreach(BusinessCardViewModel card in CardList)
                {
                    if(card.BusinessCard.GUID == guid)
                    {
                        if(!card.IsSelected)
                        {
                            card.IsSelected = true;
                        }
                    }
                    else
                    {
                        card.IsSelected = false;
                    }
                }

                OnPropertyChanged();
            }
        }

    }
}

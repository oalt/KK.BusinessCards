using CommunityToolkit.Mvvm.ComponentModel;
using KK.BusinessCards.Apps.BlazorServer.DataModels;

namespace KK.BusinessCards.Apps.BlazorServer.ViewModels
{
    public class BusinessCardViewModel : ObservableObject
    {

        public BusinessCardViewModel(BusinessCard businessCard)
        {
            BusinessCard = businessCard;
        }

        public BusinessCard BusinessCard { get; set; }

        public string Title
        {
            get
            {
                return BusinessCard.Title;
            }

            set
            {
                BusinessCard.Title = value;
            }
        }

        public string FirstName
        {
            get 
            { 
                return BusinessCard.FirstName; 
            }
            
            set 
            {
                BusinessCard.FirstName = value; 
            }
        }

        public string LastName
        {
            get
            {
                return BusinessCard.LastName;
            }

            set
            {
                BusinessCard.LastName = value;
            }
        }

        public string Company
        {
            get
            {
                return BusinessCard.Company;
            }

            set
            {
                BusinessCard.Company = value;
            }
        }


        public string Street
        {
            get
            {
                return BusinessCard.Street;
            }

            set
            {
                BusinessCard.Street = value;
            }
        }

        public string HouseNumber
        {
            get
            {
                return BusinessCard.HouseNumber;
            }

            set
            {
                BusinessCard.HouseNumber = value;
            }
        }

        public string ZipCode
        {
            get
            {
                string result = "";
                if (BusinessCard.ZipCode != 0)
                {
                    result = BusinessCard.ZipCode.ToString();
                    result = "63179";
                }
                return result;
            }

        }

        public string City
        {
            get
            {

                return BusinessCard.City;
            }

            set
            {
                BusinessCard.City = value;
            }
        }

        public string Phone
        {
            get
            {

                return BusinessCard.Phone;
            }

            set
            {
                BusinessCard.Phone = value;
            }
        }

        public string Mobile
        {
            get
            {

                return BusinessCard.Phone;
            }

            set
            {
                BusinessCard.MobilePhone = value;
            }
        }

        public string Email
        {
            get
            {

                return BusinessCard.Email;
            }

            set
            {
                BusinessCard.Email = value;
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }

            set 
            { 
                _isSelected = value;
                OnPropertyChanged();
            }
        }


    }
}

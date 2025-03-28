namespace KK.BusinessCards.Apps.BlazorServer.DataModels
{
    public class BusinessCard : ICloneable
    {

        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public string Company { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Title { get; set; } = "";

        public string Street { get; set; } = "";

        public string HouseNumber { get; set; } = "";

        public int ZipCode { get; set; }

        public string City { get; set; } = "";

        public string Country { get; set; } = "";

        public string Phone { get; set; } = "";

        public string MobilePhone { get; set; } = "";

        public string Email { get; set; } = "";

        public object Clone()
        {
            BusinessCard result = new BusinessCard();

            result.GUID = GUID;
            result.Company = Company;
            result.FirstName = FirstName;
            result.LastName = LastName;
            result.Title = Title;
            result.Street = Street;
            result.HouseNumber = HouseNumber;
            result.ZipCode = ZipCode;
            result.City = City;
            result.Country = Country;
            result.Phone = Phone;
            result.MobilePhone = MobilePhone;
            result.Email = Email;

            return result;
        }
    }
}

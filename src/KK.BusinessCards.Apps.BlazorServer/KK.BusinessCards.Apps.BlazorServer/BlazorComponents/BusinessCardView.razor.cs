using Microsoft.AspNetCore.Components;
using KK.BusinessCards.Apps.BlazorServer.ViewModels;

namespace KK.BusinessCards.Apps.BlazorServer.BlazorComponents
{
    public partial class BusinessCardView
    { 

        [Parameter]
        public BusinessCardViewModel DataContext { get; set; }
      
        protected override void OnInitialized()
        {
            //DataContext.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
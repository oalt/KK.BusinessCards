using Microsoft.AspNetCore.Components;
using KK.BusinessCards.Apps.BlazorServer.ViewModels;

namespace KK.BusinessCards.Apps.BlazorServer.Pages
{
    public partial class Index
    {
        [Inject]
        public CardListViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += DataContextPropertyChanged;
        }

        private void DataContextPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        private void HandleCardClick(string guid)
        {
            DataContext.SelectionChangedCommand.Execute(guid);
        }
    }
}
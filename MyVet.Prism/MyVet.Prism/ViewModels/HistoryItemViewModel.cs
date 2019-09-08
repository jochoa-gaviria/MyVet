using MyVet.Common.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Prism.ViewModels
{
    public class HistoryItemViewModel : HistoryResponse
    {
        private readonly INavigationService _navigatioService;
        private DelegateCommand _selectHistoryCommand;

        public HistoryItemViewModel(INavigationService navigatioService)
        {
            _navigatioService = navigatioService;
        }

        public DelegateCommand SelectHistoryCommand => _selectHistoryCommand ?? (_selectHistoryCommand = new DelegateCommand(SelectHistory));

        private async void SelectHistory()
        {
            var parameters = new NavigationParameters
            {
                {"history", this}
            };
            await _navigatioService.NavigateAsync("HistoryPage", parameters);
        }
    }
}

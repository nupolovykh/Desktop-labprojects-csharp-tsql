using Lab8.Commands;
using Lab8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab8.ViewModels
{
    internal class ExplorerViewModel : ViewModelBase
    {
        private readonly IMVVMNavigationService _navigation;
		private readonly IDropBoxReferModule _refer;

		public ExplorerViewModel(IMVVMNavigationService navigation, IDropBoxReferModule refer)
        {
            Title = "Explorer";
			_navigation = navigation;
			_refer = refer;

			exhibitted_token = _refer.Token;
		}

		private string exhibitted_token;

		public string ExhibittedToken
		{
			get { return exhibitted_token; }
			set { exhibitted_token = value; }
		}

	}
}

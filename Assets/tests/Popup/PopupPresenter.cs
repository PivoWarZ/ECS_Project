using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Popup
{
    public sealed class PopupPresenter
    {
        private readonly PopupView _view;
        private PopupViewModel _viewModel;

        public PopupPresenter()
        {  
            _view = Object.FindFirstObjectByType<PopupView>(FindObjectsInactive.Include);
        }
        
        public async UniTask<int> ShowPopupAsync()
        {
            _viewModel = new PopupViewModel();
            _view.Initialize(_viewModel);
            _view.Show();
            
            int isResponseResult = await _viewModel.OnResponseAsync();
            return isResponseResult;
        }
    }
}

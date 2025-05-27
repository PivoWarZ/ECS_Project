using System;
using Cysharp.Threading.Tasks;

namespace Code.Popup
{
    public sealed class PopupViewModel
    {
        private readonly UniTaskCompletionSource<int> _completionSource = new();
        
        public void PositiveResponse(int i)
        {
            _completionSource.TrySetResult(i);
        }

        public void NegativeResponse(int i)
        {
            _completionSource.TrySetResult(i);
        }

        public async UniTask<int> OnResponseAsync()
        {
            return await _completionSource.Task;
        }
    }
}

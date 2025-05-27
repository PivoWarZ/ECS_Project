using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.CancellationTokenSourceExample
{
    public sealed class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Button _startButton; 
        [SerializeField] private Button _cancelButton;
        [SerializeField] private TMP_Text _progressBar;
        
        private CancellationTokenSource _cancellationTokenSource;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartProgress);
            _cancelButton.onClick.AddListener(CancelProgress);
        }
        
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartProgress);
            _cancelButton.onClick.RemoveListener(CancelProgress);
        }

        private void StartProgress()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
            ProgressAsync(_cancellationTokenSource.Token).Forget();
            //NameMethod(CancellationToken.None).Forget();
        }

        private void CancelProgress()
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTaskVoid NameMethod(CancellationToken cancellationToken)
        {
            var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cancellationTokenSource.Token);
            await UniTask.WaitForSeconds(10.0f, cancellationToken: cancellationTokenSource.Token); 
            
            Debug.LogError("Download Start");
        }
        
        private async UniTaskVoid ProgressAsync(CancellationToken cancellationToken)
        {
            Debug.LogError("Download Start");
            int counter = await PreLoad(cancellationToken);
            await ProgressAsync(counter, cancellationToken).SuppressCancellationThrow();
            Debug.LogError("Download complete");
        }

        private async UniTask<int> PreLoad(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3.0f), cancellationToken: cancellationToken);
            return 10;
        }

        private async UniTask ProgressAsync(int counter, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _progressBar.text = $"{counter}%";
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: cancellationToken);
                counter++;
            }
        }
    }
}

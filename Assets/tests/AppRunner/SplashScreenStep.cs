using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace Code.AppRunner
{
    public sealed class SplashScreenStep : StepApplicationRunner
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private GameObject _disableOnEnd;
        private readonly UniTaskCompletionSource _cancellationTokenSource = new ();

        private void OnClipEnded(VideoPlayer source)
        {
            _cancellationTokenSource.TrySetResult();
        }

        public override string Title => String.Empty;

        public override async UniTask WaitOnCompleted()
        {
            _disableOnEnd.SetActive(true);
            _videoPlayer.Play();
            int frameRate = Mathf.RoundToInt(_videoPlayer.frameRate);
            Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreenMode, frameRate);
            Application.targetFrameRate = frameRate;
            _videoPlayer.loopPointReached += OnClipEnded;
            await _cancellationTokenSource.Task;
            _videoPlayer.loopPointReached -= OnClipEnded;
            _disableOnEnd.SetActive(false);
        }
    }
}

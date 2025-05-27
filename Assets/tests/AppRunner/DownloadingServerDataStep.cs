using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.AppRunner
{
    public sealed class DownloadingServerDataStep : StepApplicationRunner
    {
        [SerializeField] private float _waitTime = 3.0f;
        [SerializeField] private string _title = "Downloading Server Data";
        public override string Title => _title;

        public override async UniTask WaitOnCompleted()
        {
            await UniTask.Delay((int)(_waitTime * 1000));
            await UniTask.CompletedTask;
        }
    }
}

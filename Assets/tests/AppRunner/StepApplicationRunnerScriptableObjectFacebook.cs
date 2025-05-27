using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.AppRunner
{
    [CreateAssetMenu(fileName = "StepApplicationRunnerScriptableObjectFacebook", 
        menuName = "AppRunner/StepApplicationRunnerScriptableObject)")]
    public sealed class StepApplicationRunnerScriptableObjectFacebook : StepApplicationRunnerScriptableObject
    {
        [SerializeField] private float _waitTime = 3.0f;
        [SerializeField] private string _title = "Downloading Facebook Data";
        public override string Title => _title;
        public override async UniTask WaitOnCompleted()
        {
            await UniTask.Delay((int)(_waitTime * 1000));
            await UniTask.CompletedTask;
        }

    }
}

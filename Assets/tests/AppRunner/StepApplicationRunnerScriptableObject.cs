using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.AppRunner
{
    public abstract class StepApplicationRunnerScriptableObject : ScriptableObject
    {
        public abstract UniTask WaitOnCompleted();
        public abstract string Title { get; }
    }
}

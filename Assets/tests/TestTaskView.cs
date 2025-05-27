using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class TestTaskView: MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        private UniTaskCompletionSource _completion = new();
        private int value = 10;

        private void OnEnable()
        {
            _button.onClick.AddListener(Clicked);
            _text.text = value.ToString();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Clicked);
        }

        private void Start()
        {
            SwithValueAsync().Forget();
        }
        
        private void Clicked()
        {
            _completion.TrySetResult();
        }

        private async UniTaskVoid SwithValueAsync()
        {
            Debug.Log("SwithValueAsync()");
            await _completion.Task;
            value--;
            _text.text = value.ToString();
            _completion = new UniTaskCompletionSource();
            SwithValueAsync().Forget();
        }
    }
}
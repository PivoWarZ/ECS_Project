using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Popup
{
    public sealed class ExamplePopup : MonoBehaviour
    {
        [SerializeField] private KeyCode _openKeyCode = KeyCode.Alpha1;
        private PopupPresenter _presenter;

        private void Start()
        {
            _presenter = new PopupPresenter();
        }

        private void ResultChange(bool isPositive)
        {
            if (isPositive)
            {
                Debug.LogError("))))))");
            }
            else
            {
                Debug.LogError("(((((((");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(_openKeyCode))
            {
                ShowPopupAsync().Forget();
            }
            Debug.LogWarning("VAR");
        }

        private async UniTaskVoid ShowPopupAsync()
        {
            int isPositive = await _presenter.ShowPopupAsync();
            Debug.LogError(isPositive);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Code.Popup
{
    public sealed class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _positiveResponseButton;
        [SerializeField] private Button _negativeResponseButton;
        private PopupViewModel _popupViewModel;

        public void Initialize(PopupViewModel popupViewModel)
        {
            _popupViewModel = popupViewModel;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _positiveResponseButton.onClick.AddListener(PositiveResponseButtonOnClick);
            _negativeResponseButton.onClick.AddListener(NegativeResponseButtonOnClick);
        }

        private void OnDisable()
        {
            _positiveResponseButton.onClick.RemoveListener(PositiveResponseButtonOnClick);
            _negativeResponseButton.onClick.RemoveListener(NegativeResponseButtonOnClick);
            _popupViewModel = null;
        }

        private void PositiveResponseButtonOnClick()
        {
            _popupViewModel.PositiveResponse(10);
            Hide();
        }

        private void NegativeResponseButtonOnClick()
        {
            _popupViewModel.NegativeResponse(15);
            Hide();
        }
    }
}

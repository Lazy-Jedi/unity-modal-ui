using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Uee.UI.Modal
{
    public class ModalUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("Title Text")]
        [SerializeField]
        private TMP_Text TitleText;

        [Header("Message Text")]
        [SerializeField]
        private TMP_Text MessageText;

        [Header("Buttons Text")]
        public Button SaveButton;
        public Button YesButton;
        public Button NoButton;
        public Button CancelButton;

        [Header("Modal Properties")]
        public ModalResult ModalResult = ModalResult.NONE;

        private TaskCompletionSource<ModalResult> _modalResultTask;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            SaveButton.onClick.AddListener(OnSaveButton);
            YesButton.onClick.AddListener(OnYesButton);
            NoButton.onClick.AddListener(OnNoButton);
            CancelButton.onClick.AddListener(OnCancelButton);
            ModalResult = ModalResult.NONE;
        }

        private void OnDisable()
        {
            SaveButton.onClick.RemoveListener(OnSaveButton);
            YesButton.onClick.RemoveListener(OnYesButton);
            NoButton.onClick.RemoveListener(OnNoButton);
            CancelButton.onClick.RemoveListener(OnCancelButton);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Show Modal Window
        /// </summary>
        /// <returns></returns>
        public async Task<ModalResult> Show()
        {
            gameObject.Activate();
            return await ModalResultTask();
        }

        /// <summary>
        /// Show Modal Window and Update the Title and Message of the Window
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ModalResult> Show(string title, string message)
        {
            TitleText.SetText(title);
            MessageText.SetText(message);
            gameObject.Activate();
            return await ModalResultTask();
        }

        private Task<ModalResult> ModalResultTask()
        {
            _modalResultTask = new TaskCompletionSource<ModalResult>();
            return _modalResultTask.Task;
        }

        #endregion

        #region BUTTON METHODS

        private void OnSaveButton()
        {
            ModalResult = ModalResult.OK;
            _modalResultTask?.TrySetResult(ModalResult);
            gameObject.Deactivate();
        }

        private void OnYesButton()
        {
            ModalResult = ModalResult.OK;
            _modalResultTask?.TrySetResult(ModalResult);
            gameObject.Deactivate();
        }

        private void OnNoButton()
        {
            ModalResult = ModalResult.NO;
            _modalResultTask?.TrySetResult(ModalResult);
            gameObject.Deactivate();
        }

        private void OnCancelButton()
        {
            ModalResult = ModalResult.CANCEL;
            _modalResultTask?.TrySetResult(ModalResult);
            gameObject.Deactivate();
        }

        #endregion
    }
}
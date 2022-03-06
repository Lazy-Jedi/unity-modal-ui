using System.Diagnostics;
using UnityEngine;

namespace Uee.UI.Modal.Example
{
    public class ModalUIExample : MonoBehaviour
    {
        #region VARIABLES

        [Header("Modals")]
        public ModalUI Modal;

        #endregion

        #region UNITY METHODS

        private async void Start()
        {
            ModalResult result = await Modal.Show("Hello", "Hello, Modals!");
            switch(result)
            {
                case ModalResult.OK:
                    print("Modal Result OK");
                    break;
                case ModalResult.NO:
                    print("Modal Result NO");
                    break;
            }
        }

        #endregion
    }
}
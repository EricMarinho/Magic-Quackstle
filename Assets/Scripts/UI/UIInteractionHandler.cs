using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIInteractionHandler : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUI;
        [SerializeField] private GameObject lockedDoorUI;

        #region Singleton
        public static UIInteractionHandler Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                {
                }
            }
        }
        #endregion

        public void ShowInteractionUI()
        {
            interactionUI.SetActive(true);
        }

        public void HideInteractionUI()
        {
            interactionUI.SetActive(false);
        }

        public void ShowLockedDoorUI()
        {
            lockedDoorUI.SetActive(true);
        }

        public void HideLockedDoorUI()
        {
            lockedDoorUI.SetActive(false);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController3D : PlayerController
    {
        void Start()
        {
            HideAndLockMouse();
        }

        private void HideAndLockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnetered(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExited(other.gameObject);
        }
    }
}
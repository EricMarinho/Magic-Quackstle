using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController3D : PlayerController
    {

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
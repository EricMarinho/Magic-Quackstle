using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FootHandler3D : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerController.Instance.movePlayer.ReachTheGround();
        }
    }
}
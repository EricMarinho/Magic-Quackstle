using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FootHandler2D : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController.Instance.movePlayer.ReachTheGround();
        }
    }
}
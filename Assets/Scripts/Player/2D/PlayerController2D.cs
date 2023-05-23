using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController2D : PlayerController
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEnetered(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TriggerExited(collision.gameObject);
        }

    }
}
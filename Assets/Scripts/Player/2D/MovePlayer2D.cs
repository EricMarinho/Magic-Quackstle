using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class MovePlayer2D : MovePlayer
    {
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Jump = Jump2D;
        }

        private void FixedUpdate()
        {
            rb.transform.Translate(Vector2.right * axisHorizontal * currentSpeed * Time.deltaTime, Space.World);
            
            if (axisHorizontal < 0)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(-1, 1), 0.2f);

            }
            else if (axisHorizontal > 0)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(1, 1), 0.2f);
            }
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    ReachTheGround();
        //}

        private void Jump2D()
        {
            rb.AddForce(Vector2.up * playerData._jumpForce, ForceMode2D.Impulse);
        }
    }
}
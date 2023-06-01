using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class MovePlayer3D : MovePlayer
    {
        private float axisVertical;
        //private float mouseHorizontal;
        //private float mouseVertical;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            Jump = Jump3D;
        }

        private void FixedUpdate()
        {
            axisVertical = Input.GetAxis("Vertical");

            playerAnimationHandler.SetAnimatorSpeed(Mathf.Abs(axisHorizontal) + Mathf.Abs(axisVertical));

            //mouseHorizontal = Input.GetAxis("Mouse X");
            //mouseVertical = Input.GetAxis("Mouse Y");

            //Vector3 cameraRotation = new Vector3(mouseVertical, mouseHorizontal, 0f);
            //Camera.main.transform.Rotate(cameraRotation * playerData3D._mouseSensibility * Time.deltaTime);
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 desiredMoveDirection = forward * axisVertical + right * axisHorizontal;
            rb.transform.Translate(desiredMoveDirection * currentSpeed * Time.deltaTime, Space.World);

            if (desiredMoveDirection != Vector3.zero)
            {
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(desiredMoveDirection), playerData._rotateSpeed * Time.deltaTime);
            }

        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    ReachTheGround();
        //}

        private void Jump3D()
        {
            rb.AddForce(Vector3.up * playerData._jumpForce, ForceMode.Impulse);
        }
    }
}
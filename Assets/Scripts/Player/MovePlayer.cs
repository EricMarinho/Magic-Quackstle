using Player.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class MovePlayer : MonoBehaviour
    {
        [HideInInspector] public float axisHorizontal;
        [HideInInspector] public bool isOnGround = true;
        [HideInInspector] public float currentSpeed;
        [HideInInspector] public bool isRunning = false;
        public PlayerAnimationHandler playerAnimationHandler;
        public PlayerData playerData;

        public Action Jump;

        private void Awake()
        {
            currentSpeed = playerData._walkSpeed;
        }

        private void Update()
        {

            axisHorizontal = Input.GetAxis("Horizontal");        

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerAnimationHandler.SetIsJumping(isOnGround);
                isOnGround = false;
                PlayerController.Instance.PlayJump();
                PlayerController.Instance.StopRunningAudio();
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
                playerAnimationHandler.SetAnimatorIsRunning(isRunning);
                Run();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
                StopRunning();
            }
        }

        private void Run()
        {
            if (isOnGround)
            {
                currentSpeed = playerData._runSpeed;
                PlayerController.Instance.PlayRunningAudio();
            }
        }

        private void StopRunning()
        {
            if (isOnGround)
            {
                currentSpeed = playerData._walkSpeed;
                playerAnimationHandler.SetAnimatorIsRunning(isRunning);
                PlayerController.Instance.StopRunningAudio();
            }
        }

        public void ReachTheGround()
        {
            playerAnimationHandler.SetIsJumping(false);
            isOnGround = true;
            if (isRunning) { 
                Run();
                PlayerController.Instance.PlayRunningAudio();
            }
            else
                StopRunning();
        }

        private void OnDestroy()
        {
            Jump = null;
        }
    }    

}
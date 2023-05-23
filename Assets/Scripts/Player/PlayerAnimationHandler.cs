using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.Animations;

namespace Player.Animation {
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        //#region Singleton
        //public static PlayerAnimationHandler Instance;

        //private void Awake()
        //{
        //    if(Instance == null)
        //    {
        //        Instance = this;
        //    }
        //    else
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        //#endregion

        public void SetAnimatorSpeed(float speed)
        {
            animator.SetFloat(AnimatorConsants.Speed, speed);
        }

        public void SetAnimatorIsRunning(bool isRunning)
        {
            animator.SetBool(AnimatorConsants.IsRunning, isRunning);
        }

        public void SetIsJumping(bool isJumping)
        {
            animator.SetBool(AnimatorConsants.IsJumping, isJumping);
        }
    }
}
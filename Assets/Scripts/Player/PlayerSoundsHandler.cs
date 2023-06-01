using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Audio
{
    public class PlayerSoundsHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioSource footAudioSource;
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip deathSound;

        public void PlayJumpSound()
        {
            audioSource.PlayOneShot(jumpSound);
        }

        public void PlayDieSound()
        {
            audioSource.PlayOneShot(deathSound);
        }

        public void PlayRunningAudio()
        {
            footAudioSource.Play();
        }

        public void StopRunningAudio()
        {
            footAudioSource.Stop();
        }

    }
}
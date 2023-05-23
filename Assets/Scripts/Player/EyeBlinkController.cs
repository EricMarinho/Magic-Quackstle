using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class EyeBlinkController : MonoBehaviour
    {
        [SerializeField] private GameObject eyes;

        private PlayerController playerControllerInstance;
        private float timer = 0f;
        private float randomBlinkTime = 2f;

        private void Start()
        {
            playerControllerInstance = PlayerController.Instance;
        }

        void Update()
        {
            timer += Time.deltaTime;
            if(timer > randomBlinkTime)
            {
                randomBlinkTime = Random.Range(playerControllerInstance.playerData._blinkTime.min, playerControllerInstance.playerData._blinkTime.max);
                timer = 0f;
                StartCoroutine(Blink());
            }
        }

        private IEnumerator Blink()
        {
            eyes.SetActive(false);
            yield return new WaitForSecondsRealtime(playerControllerInstance.playerData._blinkDuration);
            eyes.SetActive(true);
        }
    }
}
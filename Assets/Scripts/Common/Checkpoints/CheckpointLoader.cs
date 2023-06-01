using Constants.PlayerPrefs;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Constants.Stages;

namespace Checkpoint {
    public class CheckpointLoader : MonoBehaviour
    {
        [SerializeField] private Animation transitionAnimation;

        [SerializeField] private float fadeInDelay = 1f;
        [SerializeField] private float fadeOutDuration = 1f;

        private string[] saveString;
        private string currentStage = "3D_STAGE_1";
        private int currentCheckpoint = 1;
        private Transform[] currentStageCheckpoints;

        #region Singleton
        public static CheckpointLoader Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        #endregion

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            currentStageCheckpoints = CheckpointHandler.Instance.spawnPointsContainer.GetComponentsInChildren<Transform>();
            currentCheckpoint = int.Parse(PlayerPrefs.GetString(PlayerPrefsConstants.CONTINUE_GAME_CHECKPOINT, StagesConstants._3D_STAGE_1 + "+1").Split("+")[1]);
            SpawnAtCheckpoint(currentCheckpoint);
            Time.timeScale = 1f;
        }

        public void SpawnAtCheckpoint(int spawnIndex)
        {
            PlayerController.Instance.transform.position = currentStageCheckpoints[spawnIndex].position;
            PlayerController.Instance.transform.rotation = currentStageCheckpoints[spawnIndex].rotation;
            StartCoroutine(FadeInScene());
        }

        private void ContinueGame()
        {
            saveString = PlayerPrefs.GetString(PlayerPrefsConstants.CONTINUE_GAME_CHECKPOINT, "3D_STAGE_1+0").Split("+");
            currentStage = saveString[0];
            currentCheckpoint = int.Parse(saveString[1]);
            StartCoroutine(FadeOutAndLoadScene(currentStage));
        }

        public IEnumerator FadeOutAndLoadScene(string stageToLoad)
        {
            PlayerController.Instance.movePlayer.enabled = false;
            transitionAnimation.Play("fade_out_screen");
            yield return new WaitForSecondsRealtime(fadeOutDuration);
            SceneManager.LoadScene(stageToLoad);
        }

        public IEnumerator FadeOutAndRespawn()
        {
            PlayerController.Instance.movePlayer.enabled = false;
            transitionAnimation.Play("fade_out_screen");
            yield return new WaitForSecondsRealtime(fadeOutDuration);
            SpawnAtCheckpoint(currentCheckpoint);
        }

        private IEnumerator FadeInScene()
        {
            yield return new WaitForSecondsRealtime(fadeInDelay);
            transitionAnimation.Play("fade_in_screen");
            PlayerController.Instance.movePlayer.enabled = true;
        }

        public void SetCheckpoint(int checkpointIndex)
        {
            currentCheckpoint = checkpointIndex;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
    }
}

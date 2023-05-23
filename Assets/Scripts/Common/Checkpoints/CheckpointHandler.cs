using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants.PlayerPrefs;
using UnityEngine.SceneManagement;

namespace Checkpoint
{
    public class CheckpointHandler : MonoBehaviour
    {

        public GameObject spawnPointsContainer;
        private Transform[] stageCheckpoints;

        private int i;

        #region Singleton
        public static CheckpointHandler Instance;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void Start()
        {
            stageCheckpoints = spawnPointsContainer.GetComponentsInChildren<Transform>();
        }

        public void SaveCheckpoint(GameObject currentCheckpoint)
        {
            for(i = 0; i < stageCheckpoints.Length; i++)
            {
                if (stageCheckpoints[i] == currentCheckpoint.transform)
                {
                    PlayerPrefs.SetString(PlayerPrefsConstants.CONTINUE_GAME_CHECKPOINT,SceneManager.GetActiveScene().name +"+"+ i.ToString());
                    CheckpointLoader.Instance.SetCheckpoint(i);
                }
            }
        }
    }
}

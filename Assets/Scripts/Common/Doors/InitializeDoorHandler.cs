using Constants.PlayerPrefs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doors
{
    public class InitializeDoorHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] doors;

        private BoxCollider[] boxColliders;
        
        private void Start()
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if(PlayerPrefs.GetString(PlayerPrefsConstants.SEALED_DOORS_LIST + $"+{i}","true") == "false"){
                    boxColliders = doors[i].GetComponentsInChildren<BoxCollider>();
                    boxColliders[0].gameObject.SetActive(false);
                }
                else
                {
                    boxColliders = doors[i].GetComponentsInChildren<BoxCollider>();
                    boxColliders[1].gameObject.SetActive(false);
                }
            }
        }
    }
}
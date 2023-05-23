using Constants.PlayerPrefs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doors
{
    public class DoorHandler : MonoBehaviour
    {
        [SerializeField] private List<GameObject> doors;
        private List<bool> areDoorsSeled = new List<bool>();


        private void Start()
        {
            if(PlayerPrefs.GetString(PlayerPrefsConstants.SEALED_DOORS_LIST,"0") == "0")
            {
                for (int i = 0; i < doors.Count; i++)
                {
                    //SetActive children seal
                }
            }
        }
    }
}
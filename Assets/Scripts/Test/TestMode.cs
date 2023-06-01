using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour
{
    [SerializeField] private bool testMode = false;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

    private void Awake()
    {
        if(testMode)
        {
            foreach(GameObject go in gameObjects)
            {
                go.SetActive(true);
            }
        }
    }
}

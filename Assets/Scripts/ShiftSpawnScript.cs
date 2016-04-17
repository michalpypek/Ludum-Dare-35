using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShiftSpawnScript : MonoBehaviour
{
    public List<GameObject> SpawnList = new List<GameObject>();

    void Awake()
    {
        foreach ( GameObject obj in SpawnList)
        {
            obj.SetActive(false);
        }

        int random = Random.Range(0, SpawnList.Count);
        SpawnList[random].SetActive(true);
    }

    void Update()
    {
        if(SpawnList.Find (o => o.activeSelf)== null)
        {
            int random = Random.Range(0, SpawnList.Count);
            SpawnList[random].SetActive(true);
        }
    }
}

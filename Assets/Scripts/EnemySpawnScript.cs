using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnScript : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject EnemyPrefab;
    public GameObject Portal1, Portal2;

    void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = (GameObject)Instantiate(EnemyPrefab, Vector2.zero, Quaternion.identity);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            EnemyList.Add(obj);
        }
        InvokeRepeating("SpawnEnemy", 0, 3f);
    }

    public GameObject GetEnemy()
    {
        foreach (GameObject obj in EnemyList)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public void SpawnEnemy()
    {
        GameObject spawnedEnemy = GetEnemy();

        if (spawnedEnemy != null)
        {
            spawnedEnemy.transform.position = (RandomBool() == true ? Portal1.transform.position : Portal2.transform.position);
            spawnedEnemy.SetActive(true);
        }
    }

    bool RandomBool()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}

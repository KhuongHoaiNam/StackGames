using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PoolingManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public String item;
        public GameObject prefab;
        public int size;
    }

    public static PoolingManager Instance;
    public Camera cam;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    private Dictionary<String, Queue<GameObject>> poolDictionary;

    void Start()
    {
        SpawnStart();
        cam = Camera.main;
    }
    public void SpawnStart()
    {
        poolDictionary = new Dictionary<String, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, this.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.item, objectPool);
        }
    }
    // Khoảng cách di chuyển theo trục Y
    public float yOffset = 2.5f;

    // Biến đếm để theo dõi số lượng object đã sinh ra
    private int objectCount = 0;
    public GameObject SpawnerBlock(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        Vector3 newPosition = new Vector3(position.x, position.y + objectCount * yOffset, position.z);
        objectToSpawn.transform.position = newPosition;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(objectToSpawn);
        objectCount++;
        return objectToSpawn;
    }

    public GameObject SpawnerObj(String tag, Vector3 position, Quaternion rotatio)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objtoSpawner = poolDictionary[tag].Dequeue();
        objtoSpawner.transform.position = position;
        objtoSpawner.transform.rotation = rotatio;
        objtoSpawner.SetActive(true) ;
        poolDictionary[tag].Enqueue(objtoSpawner);
        return objtoSpawner;
    }
    public void ResetPooling(string tag)
    {
        if (!poolDictionary.ContainsKey(tag)) return;

        Queue<GameObject> objects = poolDictionary[tag];
        objectCount = 0;
        foreach (GameObject obj in objects)
        {
                obj.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string etiqueta;
        public GameObject prefabEsfera;
       
        public int size;
    }

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i <= pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabEsfera);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            poolDictionary.Add(pool.etiqueta, objectPool);

        }
    }
    //no mk no se por que
    private void FixedUpdate()
    {
        
    }
    public GameObject SpawnFromPool(string etiqueta, Vector3 position, Quaternion rotation)
    {


        if (!poolDictionary.ContainsKey(etiqueta))//
        {
            Debug.LogError("Esta estiqueta " + etiqueta + " no se encuentra en el diccionario");
        }

        GameObject objectToSpawn = poolDictionary[etiqueta].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;

        IPoolObj pooledObject = objectToSpawn.GetComponent<IPoolObj>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[etiqueta].Enqueue(objectToSpawn);
        return objectToSpawn;


    }

}
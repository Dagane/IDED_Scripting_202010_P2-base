
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSphere : MonoBehaviour
{
    [SerializeField]
    public string etiqueta;
    private ObjectPool objectPool;

    [SerializeField]
    private float spawnRate = .1f;
 
    private Player player;

    [SerializeField]
    private float firstSpawnDelay = 0;

    // Start is called before the first frame update

    private void Start()
    {
        objectPool = ObjectPool.Instance;
        
        InvokeRepeating("Spawn", firstSpawnDelay, spawnRate);
    }

    private void FixedUpdate()
    {
        

        
        

        if (player != null)
        {

            player.onPlayerDied += StopSpawning;
        }
    }

    private void StopSpawning()
    {
        CancelInvoke();
    }
    private void Spawn()
    {
        Vector3 randonPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0F, 1f), 1F, transform.position.z));
        objectPool.SpawnFromPool(etiqueta, randonPos, Quaternion.identity);
       
    }
}
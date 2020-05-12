using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerShield : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] GameManager gm;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float startSpawn = 1f;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in units")] [SerializeField] float maxXDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y,
                transform.position.z);
            if (Time.timeSinceLevelLoad > startSpawn)
            {
                GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.Euler(0, 0, 0));
            }
            if (gm.gameHasEnded == true)
            {
                prefabToSpawn.forwardForce = 10f;
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public GameObject[] itemsToSpawn;
    public Boundary boundary;
    private int globalPlatformsNumber = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void InitialSpawn()
    {
        int platformsNumber = 8;//(int)(600 / 0.5f);
        Instantiate(
            itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                         0),
            Quaternion.identity
            );
        for (int platformIndex = 1; platformIndex < platformsNumber / 2; platformIndex++)
        {
            Instantiate(
            itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                         -platformIndex),
            Quaternion.identity
            );
            Instantiate(
             itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
             new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                          platformIndex),
             Quaternion.identity
             );
        }
        globalPlatformsNumber += platformsNumber / 2;

    }

    void Spawn()
    {
        Instantiate(
            itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                        globalPlatformsNumber),
            Quaternion.identity
            );
        globalPlatformsNumber++;
        Debug.Log(globalPlatformsNumber);
    }

    void SpawnUbi()
    {
        for (int yPoisition = 0; yPoisition < 100; yPoisition++)
        {
            Instantiate(
            itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                        globalPlatformsNumber),
            Quaternion.identity
            );
            globalPlatformsNumber++;
        }
    }
}

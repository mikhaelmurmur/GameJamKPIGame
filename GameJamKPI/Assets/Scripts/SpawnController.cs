using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    public GameObject[] itemsToSpawn;
    public Boundary boundary;
    private int globalPlatformsNumber = 0;
    private List<GameObject> platforms = new List<GameObject>();
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
        int platformsNumber = 10;
        platforms.Add((GameObject)Instantiate(
            itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                0),
            Quaternion.identity
            ));
        for (int platformIndex = 1; platformIndex < platformsNumber / 2; platformIndex++)
        {
            platforms.Add((GameObject)Instantiate(
            itemsToSpawn[0],
            new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                         -platformIndex),
            Quaternion.identity
            ));
            platforms.Add((GameObject)Instantiate(
             itemsToSpawn[0],
             new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                          platformIndex),
             Quaternion.identity
             ));
        }
        globalPlatformsNumber += platformsNumber / 2;

    }

    void Spawn()
    {
        SpawnPlatform();
        Debug.Log(globalPlatformsNumber);
    }

    void SpawnUbi()
    {
        for (int yPoisition = 0; yPoisition < 100; yPoisition++)
        {
            SpawnPlatform();
        }
    }

    void Reset()
    {
        foreach (GameObject platform in platforms)
        {
            Destroy(platform);
        }
        platforms.Clear();
        globalPlatformsNumber = 0;
    }

    private void SpawnPlatform()
    {
        int randomVar = Random.Range(0, 99);
        if (randomVar < 76)
        {
            platforms.Add((GameObject)Instantiate(
                itemsToSpawn[0],
                new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                    globalPlatformsNumber),
                Quaternion.identity
            ));
        }
        else
        {
            if (randomVar < 88)
                platforms.Add((GameObject)Instantiate(
                     itemsToSpawn[1],
                     new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                         globalPlatformsNumber),
                     Quaternion.identity
                ));
            else
            {
                if (randomVar < 97)
                {
                    platforms.Add((GameObject)Instantiate(
                        itemsToSpawn[2],
                        new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                            globalPlatformsNumber),
                        Quaternion.identity
                    ));
                }
                else
                {
                    platforms.Add((GameObject)Instantiate(
                         itemsToSpawn[3],
                         new Vector3(Random.Range(boundary.xMin, boundary.xMax),
                             globalPlatformsNumber),
                         Quaternion.identity
                    ));
                }
            }
        }
        globalPlatformsNumber++;
    }
}

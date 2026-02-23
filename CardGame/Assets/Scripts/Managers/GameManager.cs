using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerSpawnAmountMax;
    public int spawned;

    private int points = 0;

    public Transform[] spawnPoints;
    public GameObject player;

    public List<Transform> usedSpawnPoints;

    public float spawnTime;
    public float spawnTimeLeft = 0f;

    public void Start()
    {
        usedSpawnPoints = new List<Transform>();
    }

    private void Update()
    {
        int spawnPointIndex = points;

        if (spawned >= playerSpawnAmountMax)
        {
            return;
        }

        if (!usedSpawnPoints.Contains(spawnPoints[spawnPointIndex]) && spawnTimeLeft >= spawnTime)
        {
            Instantiate(player, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            usedSpawnPoints.Add(spawnPoints[spawnPointIndex]);

            spawnTimeLeft = 0f;
            spawned++;
            points++;
        }
        else
        {
            spawnTimeLeft = spawnTimeLeft + Time.deltaTime;
        }
    }
}

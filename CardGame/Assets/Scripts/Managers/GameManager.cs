using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerSpawnAmountMax;
    public int spawned;

    private int points = 0;

    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    public List<Transform> usedSpawnPoints;
    public List<GameObject> playerTurnOrder;

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
            GameObject player = Instantiate(playerPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            playerTurnOrder.Add(player);
            usedSpawnPoints.Add(spawnPoints[spawnPointIndex]);

            spawnTimeLeft = 0f;
            spawned++;
            points++;

            NextPlayerTurn();
        }
        else
        {
            spawnTimeLeft = spawnTimeLeft + Time.deltaTime;
        }
    }

    public void NextPlayerTurn()
    {
        for (int i = 0; i <= playerTurnOrder.Count; i++)
        {
            if (i == 0)
            {
                //Player 1 turn
                Debug.Log("Player 1 turn");
                i++;
            }
            else if (i == 1)
            {
                //Player 2 turn
                Debug.Log("Player 2 turn");
                i++;
            }
            else if (i == 2)
            {
                //Player 3 turn
                Debug.Log("Player 3 turn");
                i++;
            }
            else if (i == 3)
            {
                //Player 4 turn
                Debug.Log("Player 4 turn");
                i++;
            }
            else if (i == 4)
            {
                Debug.Log("Back to player 1 turn");
                i = 0;
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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

    public float delayStart;

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

            StartCoroutine(DelayAfterSpawn());
        }
        else
        {
            spawnTimeLeft = spawnTimeLeft + Time.deltaTime;
        }
    }

    IEnumerator DelayAfterSpawn()
    {
        yield return new WaitForSeconds(delayStart);
        PlayerOneTurn();
    }

    public void PlayerOneTurn()
    {
        GameObject player1 = playerTurnOrder[0];

        Player playerOne = player1.GetComponent<Player>();
        playerOne.isPlayerTurn = true;
        Debug.Log(playerOne.playerName + " turn");

        PlayerTwoTurn();
    }

    public void PlayerTwoTurn()
    {
        GameObject player2 = playerTurnOrder[1];

        Player playerTwo = player2.GetComponent<Player>();
        playerTwo.isPlayerTurn = true;
        Debug.Log(playerTwo.playerName + " turn");

        PlayerThreeTurn();
    }

    public void PlayerThreeTurn()
    {
        GameObject player3 = playerTurnOrder[2];

        Player playerThree = player3.GetComponent<Player>();
        playerThree.isPlayerTurn = true;
        Debug.Log(playerThree.playerName + " turn");

        PlayerFourTurn();
    }

    public void PlayerFourTurn()
    {
        GameObject player4 = playerTurnOrder[3];

        Player playerFour = player4.GetComponent<Player>();
        playerFour.isPlayerTurn = true;
        Debug.Log(playerFour.playerName + " turn");
    }
}

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

    public bool isPlayerOneTurn;
    public bool isPlayerTwoTurn;
    public bool isPlayerThreeTurn;
    public bool isPlayerFourTurn;

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

            isPlayerOneTurn = true;
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
        isPlayerOneTurn = true;

        playerOne.DrawPhase();
    }

    public void PlayerTwoTurn()
    {
        GameObject player2 = playerTurnOrder[1];
        Player playerTwo = player2.GetComponent<Player>();

        playerTwo.isPlayerTurn = true;
        isPlayerTwoTurn = true;

        playerTwo.DrawPhase();
    }

    public void PlayerThreeTurn()
    {
        GameObject player3 = playerTurnOrder[2];
        Player playerThree = player3.GetComponent<Player>();

        playerThree.isPlayerTurn = true;
        isPlayerThreeTurn = true;

        playerThree.DrawPhase();
    }

    public void PlayerFourTurn()
    {
        GameObject player4 = playerTurnOrder[3];
        Player playerFour = player4.GetComponent<Player>();

        playerFour.isPlayerTurn = true;
        isPlayerFourTurn = true;

        playerFour.DrawPhase();
    }
}

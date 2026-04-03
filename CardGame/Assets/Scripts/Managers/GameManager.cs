using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

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
    public bool playerIsEndingTheirTurn;

    public TMP_Text turnText;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    private Player playerOne;
    private Player playerTwo;
    private Player playerThree;
    private Player playerFour;

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

            if (playerTurnOrder.Count == 4)
            {
                PlayerOneTurn();
            }
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
        player1 = playerTurnOrder[0];
        playerOne = player1.GetComponent<Player>();

        playerOne.isPlayerTurn = true;
        isPlayerOneTurn = true;
    }

    public void PlayerTwoTurn()
    {
        player2 = playerTurnOrder[1];
        playerTwo = player2.GetComponent<Player>();

        playerTwo.isPlayerTurn = true;
        isPlayerTwoTurn = true;
    }

    public void PlayerThreeTurn()
    {
        player3 = playerTurnOrder[2];
        playerThree = player3.GetComponent<Player>();

        playerThree.isPlayerTurn = true;
        isPlayerThreeTurn = true;
    }

    public void PlayerFourTurn()
    {
        player4 = playerTurnOrder[3];
        playerFour = player4.GetComponent<Player>();

        playerFour.isPlayerTurn = true;
        isPlayerFourTurn = true;
    }

    public void EndTurn()
    {
        playerIsEndingTheirTurn = true;

        if (isPlayerOneTurn && playerIsEndingTheirTurn)
        {
            playerIsEndingTheirTurn = false;
            isPlayerOneTurn = false;
            playerOne.isPlayerTurn = false;
            PlayerTwoTurn();
        }
        else if (isPlayerTwoTurn && playerIsEndingTheirTurn)
        {
            playerIsEndingTheirTurn = false;
            isPlayerTwoTurn = false;
            playerTwo.isPlayerTurn = false;
            PlayerThreeTurn();
        }
        else if (isPlayerThreeTurn && playerIsEndingTheirTurn)
        {
            playerIsEndingTheirTurn = false;
            isPlayerThreeTurn = false;
            playerThree.isPlayerTurn = false;
            PlayerFourTurn();
        }
        else if (isPlayerFourTurn && playerIsEndingTheirTurn)
        {
            playerIsEndingTheirTurn = false;
            isPlayerFourTurn = false;
            playerFour.isPlayerTurn = false;
            PlayerOneTurn();
        }
    }
}

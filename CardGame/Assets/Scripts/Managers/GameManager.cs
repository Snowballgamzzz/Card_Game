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
    public bool playerOneHasTarget;
    public bool playerTwoHasTarget;
    public bool playerThreeHasTarget;
    public bool playerFourHasTarget;
    public bool playerIsEndingTheirTurn;
    public bool allPlayersHaveTargets;

    public TMP_Text turnText;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    public Transform playerCamera;

    private Player playerOne;
    private Player playerTwo;
    private Player playerThree;
    private Player playerFour;

    public void Start()
    {
        usedSpawnPoints = new List<Transform>();
        playerOneHasTarget = true;
        playerTwoHasTarget = true;
        playerThreeHasTarget = true;
        playerFourHasTarget = true;
        allPlayersHaveTargets = true;
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

        if (!playerOneHasTarget)
        {
            playerOne.playerTargeting = true;
        }

        playerCamera.transform.position = player1.transform.position;
        playerCamera.transform.rotation = player1.transform.rotation;
    }

    public void PlayerTwoTurn()
    {
        player2 = playerTurnOrder[1];
        playerTwo = player2.GetComponent<Player>();

        playerTwo.isPlayerTurn = true;
        isPlayerTwoTurn = true;

        if (!playerTwoHasTarget)
        {
            playerTwo.playerTargeting = true;
        }

        playerCamera.transform.position = player2.transform.position;
        playerCamera.transform.rotation = player2.transform.rotation;
    }

    public void PlayerThreeTurn()
    {
        player3 = playerTurnOrder[2];
        playerThree = player3.GetComponent<Player>();

        playerThree.isPlayerTurn = true;
        isPlayerThreeTurn = true;

        if (!playerThreeHasTarget)
        {
            playerThree.playerTargeting = true;
        }

        playerCamera.transform.position = player3.transform.position;
        playerCamera.transform.rotation = player3.transform.rotation;
    }

    public void PlayerFourTurn()
    {
        player4 = playerTurnOrder[3];
        playerFour = player4.GetComponent<Player>();

        playerFour.isPlayerTurn = true;
        isPlayerFourTurn = true;

        if (!playerFourHasTarget)
        {
            playerFour.playerTargeting = true;
        }

        playerCamera.transform.position = player4.transform.position;
        playerCamera.transform.rotation = player4.transform.rotation;
    }

    public void EndTurn()
    {
        player1 = playerTurnOrder[0];
        playerOne = player1.GetComponent<Player>();

        player2 = playerTurnOrder[1];
        playerTwo = player2.GetComponent<Player>();

        player3 = playerTurnOrder[2];
        playerThree = player3.GetComponent<Player>();

        player4 = playerTurnOrder[3];
        playerFour = player4.GetComponent<Player>();

        if (!playerOne.playerTargeting && !playerTwo.playerTargeting && !playerThree.playerTargeting && !playerFour.playerTargeting)
        {
            playerIsEndingTheirTurn = true;

            if (isPlayerOneTurn && playerIsEndingTheirTurn)
            {
                playerIsEndingTheirTurn = false;
                isPlayerOneTurn = false;
                playerOne.isPlayerTurn = false;
                playerOneHasTarget = false;
                PlayerTwoTurn();
            }
            else if (isPlayerTwoTurn && playerIsEndingTheirTurn)
            {
                playerIsEndingTheirTurn = false;
                isPlayerTwoTurn = false;
                playerTwo.isPlayerTurn = false;
                playerTwoHasTarget = false;
                PlayerThreeTurn();
            }
            else if (isPlayerThreeTurn && playerIsEndingTheirTurn)
            {
                playerIsEndingTheirTurn = false;
                isPlayerThreeTurn = false;
                playerThree.isPlayerTurn = false;
                playerThreeHasTarget = false;
                PlayerFourTurn();
            }
            else if (isPlayerFourTurn && playerIsEndingTheirTurn)
            {
                playerIsEndingTheirTurn = false;
                isPlayerFourTurn = false;
                playerFour.isPlayerTurn = false;
                playerFourHasTarget = false;
                allPlayersHaveTargets = false;
                Target();
            }
        }
    }

    public void Target()
    {
        if (!isPlayerOneTurn && !allPlayersHaveTargets)
        {
            PlayerOneTurn();
        }
        else if (isPlayerOneTurn && !allPlayersHaveTargets && !playerOneHasTarget)
        {
            playerOneHasTarget = true;
            playerOne.isPlayerTurn = false;
            PlayerTwoTurn();
        }
        else if (isPlayerTwoTurn && !allPlayersHaveTargets && !playerTwoHasTarget)
        {
            playerTwo.isPlayerTurn = false;
            playerTwoHasTarget = true;
            PlayerThreeTurn();
        }
        else if (isPlayerThreeTurn && !allPlayersHaveTargets && !playerThreeHasTarget)
        {
            playerThree.isPlayerTurn = false;
            playerThreeHasTarget = true;
            PlayerFourTurn();
        }
        else if (isPlayerFourTurn && !allPlayersHaveTargets && !playerFourHasTarget)
        {
            playerFour.isPlayerTurn = false;
            playerFourHasTarget = true;
            allPlayersHaveTargets = true;
            PlayerOneTurn();
        }
    }
}

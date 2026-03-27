using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float followerCount;
    public string playerName;
    public int drawAmount;

    [Header("Booleans")]
    public bool isBeingTargetted;
    public bool playingHeroCard;
    public bool playingMonsterCard;
    public bool playingFestivalCard;
    public bool isPlayerTurn;

    [Header("Transforms")]
    private int slotIndex;
    public Transform[] cardSlots;
    public List<Transform> occupiedCardSlot;

    [Header("Script References")]
    GameManager manager;
    CardDeck deck;

    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();

        deck = FindAnyObjectByType<CardDeck>();

        playerName = ("Player " + manager.spawned);

        isPlayerTurn = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            EndPhase();
        }
    }

    public void PlayCardPhase()
    {

    }

    public void DrawPhase()
    {
        deck.cardIndex = Random.Range(0, deck.deck.Length);
        deck.card = deck.deck[deck.cardIndex];

        int playerSlotIndex = slotIndex;

        if (!occupiedCardSlot.Contains(cardSlots[playerSlotIndex]) && drawAmount >= 1)
        {
            GameObject playerCard = Instantiate(deck.card, cardSlots[playerSlotIndex].position, cardSlots[playerSlotIndex].rotation);
            playerCard.transform.parent = this.gameObject.transform;

            drawAmount--;
        }
    }

    public void TargetPhase()
    {

    }

    public void EndPhase()
    {

        if (manager.isPlayerOneTurn && isPlayerTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerTwoTurn = true;
            manager.isPlayerOneTurn = false;
        }
        else if (manager.isPlayerTwoTurn && isPlayerTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerTwoTurn = false;
            manager.isPlayerThreeTurn = true;
        }
        else if (manager.isPlayerThreeTurn && isPlayerTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerThreeTurn = false;
            manager.isPlayerFourTurn = true;
        }
        else if (manager.isPlayerFourTurn && isPlayerTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerFourTurn = false;
        }
    }
}

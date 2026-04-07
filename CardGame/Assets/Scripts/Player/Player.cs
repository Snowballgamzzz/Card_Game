using UnityEngine;
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
    public bool playerEndsTurn;

    [Header("Transforms")]
    private int slotIndex;
    public Transform[] cardSlots;
    public List<Transform> occupiedCardSlot;
    public Transform cardPlacement;

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
        if (Input.GetKeyDown(KeyCode.P) && isPlayerTurn)
        {
            EndPhasePlayerOne();
        }
        

        if (isPlayerTurn)
        {
            manager.turnText.text = playerName + " Turn";
        }
    }

    public void PlayCardPhase()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.GetComponent<Placement>())
            {
                hit.transform.position = cardPlacement.transform.position;
                hit.transform.rotation = cardPlacement.transform.rotation;
            }
        }

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

    public void EndPhasePlayerOne()
    {
        if (manager.isPlayerOneTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerOneTurn = false;
            manager.PlayerTwoTurn();
        }
        else if (!manager.isPlayerOneTurn)
        {
            EndPhasePlayerTwo();
        }
    }

    public void EndPhasePlayerTwo()
    {
        if (manager.isPlayerTwoTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerTwoTurn = false;
            manager.PlayerThreeTurn();
        }
        else
        {
            EndPhasePlayerThree();
        }
    }

    public void EndPhasePlayerThree()
    {
        if (manager.isPlayerThreeTurn)
        {
            isPlayerTurn = false;
            manager.isPlayerThreeTurn = false;
            manager.PlayerFourTurn();
        }
        else
        {
            EndPhasePlayerFour();
        }
    }

    public void EndPhasePlayerFour()
    {

    }
}

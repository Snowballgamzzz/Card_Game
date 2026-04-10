using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    public bool playerTargeting;

    [Header("Transforms")]
    private int slotIndex;
    public Transform[] cardSlots;
    public List<Transform> occupiedCardSlot;
    public Transform cardPlacement;

    [Header("Script References")]
    GameManager manager;
    CardDeck deck;

    public GameObject targetedPlayer;

    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();

        deck = FindAnyObjectByType<CardDeck>();

        playerName = ("Player " + manager.spawned);

        isPlayerTurn = false;
    }

    private void Update()
    {
        if (isPlayerTurn && !playerTargeting)
        {
            manager.turnText.text = playerName + " Turn";
        }
        else if (isPlayerTurn && playerTargeting)
        {
            manager.turnText.text = playerName + " Select your Target";
        }

        if (playerTargeting)
        {
            TargetPhase();
        }
    }

    public void PlayCardPhase()
    {
        if (!playerTargeting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.GetComponent<Placement>() && hit.transform.gameObject.GetComponentInParent<Player>().isPlayerTurn)
                {
                    hit.transform.position = cardPlacement.transform.position;
                    hit.transform.rotation = cardPlacement.transform.rotation;
                }
            }
        }
    }

    public void DrawPhase()
    {
        if (!playerTargeting)
        {
            deck.cardIndex = Random.Range(0, deck.deck.Length);
            deck.card = deck.deck[deck.cardIndex];

            int playerSlotIndex = slotIndex;

            if (!occupiedCardSlot.Contains(cardSlots[playerSlotIndex]) && drawAmount >= 1)
            {
                GameObject playerCard = Instantiate(deck.card, cardSlots[playerSlotIndex].position, cardSlots[playerSlotIndex].rotation);
                playerCard.transform.parent = this.gameObject.transform;
                occupiedCardSlot.Add(cardSlots[playerSlotIndex]);

                slotIndex++;
                drawAmount--;
            }
        }
    }

    public void TargetPhase()
    {
        if (playerTargeting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    targetedPlayer = hit.transform.parent.gameObject;
                }
            }
        }
    }
}

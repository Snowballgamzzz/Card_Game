using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public GameObject[] deck;
    public GameObject card;
    public int cardIndex;

    public GameObject gameManager;
    GameManager manager;

    private void Start()
    {
        manager = gameManager.GetComponent<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (manager.isPlayerOneTurn)
            {
                GameObject player1 = manager.playerTurnOrder[0];
                Player playerOne = player1.GetComponent<Player>();

                playerOne.DrawPhase();
            }
            else if (manager.isPlayerTwoTurn)
            {
                GameObject player2 = manager.playerTurnOrder[1];
                Player playerTwo = player2.GetComponent<Player>();

                playerTwo.DrawPhase();
            }
            else if (manager.isPlayerThreeTurn)
            {
                GameObject player3 = manager.playerTurnOrder[2];
                Player playerThree = player3.GetComponent<Player>();

                playerThree.DrawPhase();
            }
            else if (manager.isPlayerFourTurn)
            {
                GameObject player4 = manager.playerTurnOrder[3];
                Player playerFour = player4.GetComponent<Player>();

                playerFour.DrawPhase();
            }
        }
    }
}

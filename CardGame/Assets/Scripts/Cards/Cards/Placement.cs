using UnityEngine;

public class Placement : MonoBehaviour
{
    public bool cardSelected;

    GameManager manager;

    private void Start()
    {
        manager = FindFirstObjectByType<GameManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cardSelected = true;

            if (manager.isPlayerOneTurn)
            {
                GameObject player1 = manager.playerTurnOrder[0];
                Player playerOne = player1.GetComponent<Player>();

                playerOne.PlayCardPhase();
            }
            else if (manager.isPlayerTwoTurn)
            {
                GameObject player2 = manager.playerTurnOrder[1];
                Player playerTwo = player2.GetComponent<Player>();

                playerTwo.PlayCardPhase();
            }
            else if (manager.isPlayerThreeTurn)
            {
                GameObject player3 = manager.playerTurnOrder[2];
                Player playerThree = player3.GetComponent<Player>();

                playerThree.PlayCardPhase();
            }
            else if (manager.isPlayerFourTurn)
            {
                GameObject player4 = manager.playerTurnOrder[3];
                Player playerFour = player4.GetComponent<Player>();

                playerFour.PlayCardPhase();
            }
        }
    }
}

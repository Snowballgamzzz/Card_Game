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
                manager.PlayerOneTurn();
            }
            else if (manager.isPlayerTwoTurn)
            {
                manager.PlayerTwoTurn();
            }
            else if (manager.isPlayerThreeTurn)
            {
                manager.PlayerThreeTurn();
            }
            else if (manager.isPlayerFourTurn)
            {
                manager.PlayerFourTurn();
            }
        }
    }
}

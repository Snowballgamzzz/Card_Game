using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardDatabase cardDB;

    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardTypeText;
    [SerializeField] private TextMeshProUGUI cardElementText;
    [SerializeField] private float cardFollowerCount;
    [SerializeField] private TextMeshProUGUI cardAbilityText;
    [SerializeField] private TextMeshProUGUI cardElementAbility;

    private int cardCount = 0;

    private void Start()
    {
        cardCount = 0;
        Save();

        UpdatedCardCount(cardCount);
    }

    private void UpdatedCardCount(int cardCount)
    {
        Card card = cardDB.GetCard(cardCount);
        cardNameText.text = card.cardName;
        cardTypeText.text = card.cardType;
        cardElementText.text = card.cardElement;
        cardFollowerCount = card.followerCount;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("cardCount", cardCount);
    }
}

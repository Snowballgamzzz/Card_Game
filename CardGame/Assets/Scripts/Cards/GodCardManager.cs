using TMPro;
using UnityEngine;

public class GodCardManager : MonoBehaviour
{
    [SerializeField] private GodCardDatabase godCardDB;

    [SerializeField] private TextMeshProUGUI godNameText;
    [SerializeField] private TextMeshProUGUI godPrimaryAffinityText;
    [SerializeField] private TextMeshProUGUI godSecondaryAffinityText;
    [SerializeField] private TextMeshProUGUI godAbilityText;

    private int godCardCount = 0;

    private void Start()
    {
        godCardCount = 0;
        Save();

        UpdatedGodCardCount(godCardCount);
    }

    private void UpdatedGodCardCount(int cardCount)
    {
        GodCard godCard = godCardDB.GetGod(cardCount);
        godNameText.text = godCard.godName;
        godPrimaryAffinityText.text = godCard.primaryAffinity;
        godSecondaryAffinityText.text = godCard.secondaryAffinity;
        godAbilityText.text = godCard.godAbility;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("godCardCount", godCardCount);
    }
}

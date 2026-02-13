using UnityEngine;

[CreateAssetMenu]
public class CardDatabase : ScriptableObject
{
    public Card[] cards;

    public int CardCount
    {
        get { return cards.Length; }
    }

    public Card GetCard(int index)
    {
        return cards[index];
    }
}


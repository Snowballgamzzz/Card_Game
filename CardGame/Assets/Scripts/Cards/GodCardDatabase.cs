using UnityEngine;

[CreateAssetMenu]
public class GodCardDatabase : ScriptableObject
{
    public GodCard[] godCards;

    public int godCount
    { 
         get { return godCards.Length; }
    }

    public GodCard GetGod(int index)
    {
        return godCards[index];
    }

}

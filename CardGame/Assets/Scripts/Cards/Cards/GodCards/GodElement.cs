using UnityEngine;

public class GodElement : MonoBehaviour
{
    public enum PrimaryElement
    {
        Sky,
        Earth,
        Ocean,
        Fire
    }

    public PrimaryElement primaryElement;

    public enum SecondaryElement
    {
        Sky,
        Earth,
        Ocean,
        Fire
    }

    public SecondaryElement secondaryElement;
}

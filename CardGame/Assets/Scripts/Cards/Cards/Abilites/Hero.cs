using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum HeroElement
    { 
    Fire,
    Ocean,
    Sky,
    Earth
    }

    HeroElement element;

    GodElement godElement;
    Player player;
    Fire fire;

    public float primaryFollowerCount;
    public float secondaryFollowerCount;
    public float nullFollowerCount;

    void Start()
    {
        player = GetComponentInParent<Player>();
        godElement = GetComponentInParent<GodElement>();
        fire = GetComponentInChildren<Fire>();
    }

    public void PrimaryFollowerCheck()
    {
        if (godElement.primaryElement == GodElement.PrimaryElement.Ocean && element == HeroElement.Ocean)
        {
            player.followerCount += primaryFollowerCount;
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Fire && element == HeroElement.Fire)
        {
            player.followerCount += primaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Earth && element == HeroElement.Earth)
        {
            player.followerCount += primaryFollowerCount;
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Sky && element == HeroElement.Sky)
        {
            player.followerCount += primaryFollowerCount;
        }
        else
        {
            SecondaryFollowerCheck();
        }
    }

    public void SecondaryFollowerCheck()
    {
        if (godElement.secondaryElement == GodElement.SecondaryElement.Ocean && element == HeroElement.Ocean)
        {
            player.followerCount += secondaryFollowerCount;
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Fire && element == HeroElement.Fire)
        {
            player.followerCount += secondaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Earth && element == HeroElement.Earth)
        {
            player.followerCount += secondaryFollowerCount;
        }   
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Sky && element == HeroElement.Sky)
        {
            player.followerCount += secondaryFollowerCount;
        }
        else
        {
            player.followerCount += nullFollowerCount;

            if (element == HeroElement.Fire)
            {
                fire.FireDamage(); 
            }
        }
    }
}

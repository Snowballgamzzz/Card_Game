using UnityEngine;

public class Festival : MonoBehaviour
{
    public enum FestivalElement
    { 
    Ocean,
    Sky,
    Fire,
    Earth
    }

    public FestivalElement element;

    GodElement godElement;
    Player player;
    Fire fire;
    Ocean ocean;

    public float primaryFollowerCount;
    public float secondaryFollowerCount;
    public float nullFollowerCount;

    void Start()
    {
        godElement = GetComponentInParent<GodElement>();
        player = GetComponentInParent<Player>();
        fire = GetComponent<Fire>();
        ocean = GetComponent<Ocean>();
    }

    private void Update()
    {
        PrimaryFollowerCheck();
    }

    private void PrimaryFollowerCheck()
    {
        if (godElement.primaryElement == GodElement.PrimaryElement.Ocean && element == FestivalElement.Ocean)
        {
            player.followerCount += primaryFollowerCount;
            ocean.OceanGain();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Fire && element == FestivalElement.Fire)
        {
            player.followerCount += primaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Earth && element == FestivalElement.Earth)
        {
            player.followerCount += primaryFollowerCount;
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Sky && element == FestivalElement.Sky)
        {
            player.followerCount += primaryFollowerCount;
        }
        else
        {
            SecondaryFollowerCheck();
        }
    }

    private void SecondaryFollowerCheck()
    {
        if (godElement.secondaryElement == GodElement.SecondaryElement.Ocean && element == FestivalElement.Ocean)
        {
            player.followerCount += secondaryFollowerCount;
            ocean.OceanGain();
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Fire && element == FestivalElement.Fire)
        {
            player.followerCount += secondaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Earth && element == FestivalElement.Earth)
        {
            player.followerCount += secondaryFollowerCount;
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Sky && element == FestivalElement.Sky)
        {
            player.followerCount += secondaryFollowerCount;
        }
        else
        {
            player.followerCount += nullFollowerCount;

            if (element == FestivalElement.Fire)
            {
                fire.FireDamage();
            }
            else if (element == FestivalElement.Ocean)
            {
                ocean.OceanGain();
            }
        }
    }
}

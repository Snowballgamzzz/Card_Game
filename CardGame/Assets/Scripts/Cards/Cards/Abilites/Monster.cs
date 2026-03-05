using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum MonsterElement
    { 
    Fire,
    Ocean,
    Sky,
    Earth
    }

    MonsterElement element;

    GodElement godElement;
    Target target;
    Fire fire;

    public float primaryFollowerCount;
    public float secondaryFollowerCount;
    public float nullFollowerCount;

    void Start()
    { 
        godElement = GetComponentInParent<GodElement>();
        target = GetComponentInParent<Target>();
        fire = GetComponentInChildren<Fire>();
    }

    public void PrimaryFollowerCheck()
    {
        if (godElement.primaryElement == GodElement.PrimaryElement.Ocean && element == MonsterElement.Ocean && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= primaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Fire && element == MonsterElement.Fire && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= primaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Earth && element == MonsterElement.Earth && !target.targettedPlayer.playingHeroCard)
        {   
            target.targettedPlayer.followerCount -= primaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.primaryElement == GodElement.PrimaryElement.Sky && element == MonsterElement.Sky && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= primaryFollowerCount;
            fire.FireDamage();
        }
        else
        {
            SecondaryFollowerCheck();
        }
    }

    public void SecondaryFollowerCheck()
    {
        if (godElement.secondaryElement == GodElement.SecondaryElement.Ocean && element == MonsterElement.Ocean && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= secondaryFollowerCount;
            fire.FireDamage();
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Fire && element == MonsterElement.Fire && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= secondaryFollowerCount;
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Earth && element == MonsterElement.Earth && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= secondaryFollowerCount;
        }
        else if (godElement.secondaryElement == GodElement.SecondaryElement.Sky && element == MonsterElement.Sky && !target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= secondaryFollowerCount;
        }
        else if (!target.targettedPlayer.playingHeroCard)
        {
            target.targettedPlayer.followerCount -= nullFollowerCount;
        }
    }
}

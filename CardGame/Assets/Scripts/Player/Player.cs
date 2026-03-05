using UnityEngine;

public class Player : MonoBehaviour
{
    public float followerCount;
    public string playerName;

    public bool isBeingTargetted;
    public bool playingHeroCard;
    public bool playingMonsterCard;
    public bool playingFestivalCard;

    GameManager manager;

    void Start()
    {
        manager = FindAnyObjectByType<GameManager>();

        playerName = ("Player " + manager.spawned);
    }

    public void PlayCardPhase()
    {

    }

    public void DrawPhase()
    {

    }

    public void TargetPhase()
    {

    }

    public void EndPhase()
    {

    }
}

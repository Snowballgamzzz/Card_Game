using UnityEngine;

public class Fire : MonoBehaviour
{
    Target target;
    public float targetFollowers;

    void Start()
    {
      target = GetComponentInParent<Target>();
    }

    public void FireDamage()
    {
        target.targettedPlayer.followerCount -= targetFollowers;
    }
}

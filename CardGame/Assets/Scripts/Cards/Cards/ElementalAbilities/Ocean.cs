using UnityEngine;

public class Ocean : MonoBehaviour
{
    Player player;
    public float followerGain;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public void OceanGain()
    {
        player.followerCount += followerGain;
    }
}

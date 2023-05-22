using UnityEngine;

public class Beginning : MonoBehaviour
{
    void Start()
    {
        LevelManager.isAbleToMove = false;

        StartCoroutine(Utility.TimedEvent(() => 
        {
            LevelManager.isAbleToMove = true;
        }, 13f));
    }
}

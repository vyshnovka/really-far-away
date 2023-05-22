using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public static bool isAbleToMove = true;

    public static bool isWearingFullSet = false;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }
}

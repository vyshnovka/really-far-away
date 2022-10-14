using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public static bool isAbleToMove = true;

    //public static bool is

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }
}

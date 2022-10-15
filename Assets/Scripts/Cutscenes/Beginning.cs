using System.Collections;
using System.Collections.Generic;
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

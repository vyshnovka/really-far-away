using System;
using System.Collections;
using UnityEngine;

public static class Utility
{
    public static IEnumerator TimedEvent(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
}

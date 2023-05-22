using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private Animator ending;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Utility.TimedEvent(() =>
        {
            LevelManager.isAbleToMove = false;
        }, 1f));

        ending.SetTrigger("end");

        StartCoroutine(Utility.TimedEvent(() =>
        {
            Application.Quit();
#if (UNITY_EDITOR)
            Debug.Log("QUIT");
#endif
        }, 15f));
    }
}

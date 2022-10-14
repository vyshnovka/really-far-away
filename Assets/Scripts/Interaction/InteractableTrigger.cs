using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class InteractableTrigger : MonoBehaviour
{
    [Header("Object to show as a prompt")]
    [SerializeField]
    private GameObject buttonWithE;
    [SerializeField]
    [Range(0, 1)]
    private float positionOffsetX = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    private float positionOffsetY = 0.5f;

    private bool isInteractable = false;

    private Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if (isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonWithE.SetActive(true);

        buttonWithE.transform.position = new Vector2(transform.position.x - positionOffsetX, transform.position.y + positionOffsetY);

        isInteractable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonWithE.SetActive(false);

        isInteractable = false;
    }
}

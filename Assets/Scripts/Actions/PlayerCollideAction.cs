using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollideAction : MonoBehaviour
{
    public UnityEvent collisionEnterAction = new UnityEvent();
    public UnityEvent collisionExitAction = new UnityEvent();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collisionEnterAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collisionExitAction?.Invoke();
        }
    }
}

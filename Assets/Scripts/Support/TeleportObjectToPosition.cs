using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectToPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject affectedObject;

    [SerializeField]
    private Transform targetPosition;

    public void DoTeleport()
    {
        affectedObject.transform.position = targetPosition.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 savedPosition;
    private void Awake()
    {
        savedPosition = transform.position;
    }

    public void RestoreInitialPosition()
    {
        transform.position = savedPosition;
    }
}

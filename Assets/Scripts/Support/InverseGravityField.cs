using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGravityField : MonoBehaviour
{
    public MovementController targetBody = null;
    private void Awake()
    {
        if (targetBody == null)
            targetBody = GameObject.FindGameObjectWithTag("Player")?.GetComponent<MovementController>();
    }

    public void ApplyGravity()
    {
        targetBody.ApplyArtificialGravity = true;
    }

    public void RestoreGravity()
    {
        targetBody.ApplyArtificialGravity = false;
    }
}

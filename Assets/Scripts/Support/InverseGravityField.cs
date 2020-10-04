using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseGravityField : MonoBehaviour
{
    private Vector3 originalGravity;
    private void Awake()
    {
        originalGravity = Physics.gravity;
    }

    public void InverseGravity()
    {
        Physics.gravity = -1 * Physics.gravity;
    }

    public void RestoreGravity()
    {
        Physics.gravity = originalGravity;
    }
}

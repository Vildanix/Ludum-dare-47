using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private bool isGrounded = false;

    public bool IsGrounded { get => isGrounded; }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Gravity Field"))
            isGrounded = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}

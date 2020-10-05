using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField]
    private bool isCollided = false;

    public bool IsCollided { get => isCollided; }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Gravity Field") && !other.CompareTag("Finish"))
            isCollided = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        isCollided = false;
    }
}

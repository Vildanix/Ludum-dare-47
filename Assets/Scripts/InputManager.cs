﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool isHorizontalSwitched = false;
    private float axisTreshold = 0.5f;

    [SerializeField]
    private bool processInputs = false;

    public void SetInputProcessing(bool status)
    {
        processInputs = status;
    }

    public bool GetJumpStart()
    {
        if (!processInputs) return false;
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetJumpActive()
    {
        if (!processInputs) return false;
        return Input.GetKey(KeyCode.Space);
    }

    public bool GetMoveLeft()
    {
        if (!processInputs) return false;
        if (isHorizontalSwitched)
            return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -axisTreshold;
        else
            return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > axisTreshold;
    }

    public bool GetMoveRight()
    {
        if (!processInputs) return false;
        if (isHorizontalSwitched)
            return Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > axisTreshold;
        else
            return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -axisTreshold;
    }
}

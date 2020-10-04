using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Horizontal movement")]
    [SerializeField]
    [Range(1.0f, 20.0f)]
    private float horizontralSpeed = 2.5f;

    [Header("Jumping")]
    // jump variables
    [SerializeField]
    [Range(0.1f, 5.0f)]
    private float jumpForce = 1.1f;

    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float fallingForceMultiplier = 0.5f;

    [SerializeField]
    private AnimationCurve jumpSupportForce = new AnimationCurve();

    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float jumpSupportForceMultiplier = 0.5f;

    private float jumpTimer;

    // Reference fields
    [Header("References")]
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private Rigidbody rigidBody;

    [SerializeField]
    private GroundChecker groundChecker;

    public AudioSource jumpAudio;

    // Start is called before the first frame update
    void Awake()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();

        if (inputManager == null)
            inputManager = FindObjectOfType<InputManager>();

        if (groundChecker == null)
        {
            groundChecker = GetComponentInChildren<GroundChecker>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementDistance = MoveLeft();
        movementDistance += MoveRight();
        MoveHorizontal(movementDistance);
        Jump();
    }

    private void Jump()
    {
        if (inputManager.GetJumpActive() && groundChecker.IsGrounded)
        {
            rigidBody.velocity = -1 * Physics.gravity * jumpForce;
            jumpTimer = 0;
            if (!jumpAudio.isPlaying)
                jumpAudio.Play();
        }

        // short jump without jump button
        if (!inputManager.GetJumpActive() && Vector3.Dot(rigidBody.velocity, Physics.gravity) < 0)
        {
            float supportForce = jumpSupportForce.Evaluate(jumpTimer) * jumpSupportForceMultiplier;
            rigidBody.velocity += Physics.gravity * supportForce * Time.deltaTime; 
        }

        if (Vector3.Dot(rigidBody.velocity, Physics.gravity) > 0)
        {
            rigidBody.velocity += Physics.gravity * fallingForceMultiplier * Time.deltaTime;
        }

        jumpTimer += Time.deltaTime;
    }

    private float MoveLeft()
    {
        if (inputManager.GetMoveLeft())
        {
            return (-1 * horizontralSpeed * Time.deltaTime);
        }

        return 0f;
    }

    private float MoveRight()
    {
        if (inputManager.GetMoveRight())
        {
            return (horizontralSpeed * Time.deltaTime);
        }

        return 0f;
    }

    private void MoveHorizontal(float distance)
    {
        rigidBody.MovePosition(transform.position + new Vector3(distance, 0, 0));
    }
}

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
    private CollisionChecker groundChecker = null;

    [SerializeField]
    private CollisionChecker gravityGroundChecker = null;

    [SerializeField]
    private CollisionChecker leftMovementChecker = null;

    [SerializeField]
    private CollisionChecker rightMovementChecker = null;

    public AudioSource jumpAudio;

    public bool ApplyArtificialGravity = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();

        if (inputManager == null)
            inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // horizontal movement
        float movementDistance = MoveLeft();
        movementDistance += MoveRight();
        MoveHorizontal(movementDistance);

        // jumping
        if (ApplyArtificialGravity)
            JumpInverted();
        else 
            Jump();

        // inverted gravity countering force
        ArtificialGravity();
    }

    private void Jump()
    {
        if (inputManager.GetJumpActive() && groundChecker.IsCollided)
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

    private void JumpInverted()
    {
        if (inputManager.GetJumpActive() && gravityGroundChecker.IsCollided)
        {
            rigidBody.velocity = 1 * Physics.gravity * jumpForce;
            jumpTimer = 0;
            if (!jumpAudio.isPlaying)
                jumpAudio.Play();
        }
        
        // short jump without jump button
        if (!inputManager.GetJumpActive() && Vector3.Dot(rigidBody.velocity, Physics.gravity) > 0)
        {
            float supportForce = jumpSupportForce.Evaluate(jumpTimer) * jumpSupportForceMultiplier;
            rigidBody.velocity -= Physics.gravity * supportForce * Time.deltaTime;
        }
        
        if (Vector3.Dot(rigidBody.velocity, Physics.gravity) < 0)
        {
            rigidBody.velocity -= Physics.gravity * fallingForceMultiplier * Time.deltaTime;
        }

        jumpTimer += Time.deltaTime;
    }

    private float MoveLeft()
    {
        if (inputManager.GetMoveLeft() && !leftMovementChecker.IsCollided)
        {
            return (-1 * horizontralSpeed * Time.deltaTime);
        }

        return 0f;
    }

    private float MoveRight()
    {
        if (inputManager.GetMoveRight() && !rightMovementChecker.IsCollided)
        {
            return (horizontralSpeed * Time.deltaTime);
        }

        return 0f;
    }

    private void MoveHorizontal(float distance)
    {
        rigidBody.MovePosition(transform.position + new Vector3(distance, 0, 0));
    }

    private void ArtificialGravity()
    {
        if (ApplyArtificialGravity)
        {
            rigidBody.velocity +=  -1.9f * Physics.gravity * Time.deltaTime;
        }
    }
}

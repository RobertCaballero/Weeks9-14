using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{
    public AudioSource audioSource;
    public float speed;

    public float xMovement;
    public float yMovement;

    public Animator knightAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
        transform.position += new Vector3(yMovement, 0f, 0f) * speed * Time.deltaTime;
    }

    public void OnFootstep()
    {
        Debug.Log("Footstep");

        audioSource.Play();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool isRunning = xMovement != 0f;

        knightAnimator.SetBool("isRunning", isRunning);
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        Vector2 RobertJump = context.ReadValue<Vector2>();
        yMovement = RobertJump.y;

        bool isJumping = yMovement != 0f;

        knightAnimator.SetBool("isJumping", isJumping);

    }


}

using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public float speed;
    private float xMove;
    private float yMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMove, 0f, 0f) * speed * Time.deltaTime;
        transform.position += new Vector3(0f, yMove, 0f) * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMove = moveDirection.x;
        yMove = moveDirection.y;
    }
}

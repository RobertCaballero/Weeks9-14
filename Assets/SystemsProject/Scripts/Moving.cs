using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public float speed; //Variable of speed
    private float xMove; //Variable of movement in the x axis
    private float yMove; //Variable of movement in the y axis

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMove, 0f, 0f) * speed * Time.deltaTime; //Move the player in the x axis by the value of xMove, multiplied by the speed and Time.deltaTime, so it moves every second instead of every frame
        transform.position += new Vector3(0f, yMove, 0f) * speed * Time.deltaTime; //Move the player in the y axis by the value of yMove, multiplied by the speed and Time.deltaTime, so it moves every second instead of every frame
    }

    public void OnMove(InputAction.CallbackContext context) //Use the player inoput action for it later being able to map it into the Move action
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();// Read the value of the input action and save it in a variable
        xMove = moveDirection.x; //Make xMove be de x value of the moveDirection variable
        yMove = moveDirection.y; //Make yMove be de y value of the moveDirection variable
    }
}

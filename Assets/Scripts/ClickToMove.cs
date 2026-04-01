using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{

    public LineRenderer trail;
    GameObject Player;
    //public float MousePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.transform.position = transform.position;
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            trail.positionCount++;
            trail.SetPosition(trail.positionCount - 1, mousePos);



        }

    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector3 MousePoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector3>());
        
        
    }

  

    
}

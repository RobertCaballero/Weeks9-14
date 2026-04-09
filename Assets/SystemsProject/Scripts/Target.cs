using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{

    private Camera mainCamera; //Variable of the main camera.
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main; //Set the mainCamera variable to be the main camera in the scene.
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 screenPos = Mouse.current.position.ReadValue();  //Get the position of the mouse in screen coordinates and save it in a variable.
        Vector3 mouseWorldPos = new Vector3(screenPos.x, screenPos.y, 10f); //Set the mouseWorldPos variable to be the position of the mouse in world coordinates, we set the z value to 10 so it is in front of the camera and visible in the scene.

        Vector3 targetPos = mainCamera.ScreenToWorldPoint(mouseWorldPos); //Convert mouseWorldPos from the screen coordinates to world coordinates, to later save it in a variable. 
        transform.position = new Vector3(targetPos.x, targetPos.y, 0f); //Set the position of the target to be the same coordinates as the targetPos variable, but with a z value of 0 so it is visible in the scene and not behind the camera.
    }

   

    }

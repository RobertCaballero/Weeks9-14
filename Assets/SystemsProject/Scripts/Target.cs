using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{

    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 screenPos = Mouse.current.position.ReadValue(); 
        Vector3 mouseWorldPos = new Vector3(screenPos.x, screenPos.y, 10f);

        Vector3 targetPos = mainCamera.ScreenToWorldPoint(mouseWorldPos);
        transform.position = new Vector3(targetPos.x, targetPos.y, 0f);
    }
}

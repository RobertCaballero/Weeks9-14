using UnityEngine;
using UnityEngine.InputSystem;

public class BulletMove : MonoBehaviour
{
    public player player;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

  
}

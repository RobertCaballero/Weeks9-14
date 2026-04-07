using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform SpawnPoint;
    public Transform ShootHere;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SpawnPoint.position;
    }

    public void Interact(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            GameObject SpawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        }
        
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position = Vector2.Lerp(SpawnPoint.position, ShootHere.position, 0f);
        }

        Debug.Log(context.performed);

    }



}

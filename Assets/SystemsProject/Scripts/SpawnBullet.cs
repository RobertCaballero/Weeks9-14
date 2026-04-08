using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform SpawnPoint;
    public Transform ShootHere;

    private GameObject spawnedBullet;
    private bool isBulletMoving = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBulletMoving && spawnedBullet != null)
        {
           spawnedBullet.transform.position = SpawnPoint.position;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
           spawnedBullet = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
            isBulletMoving = true;
        }


    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed && spawnedBullet !=null)
        {
            isBulletMoving = false;

            Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();

            Vector3 direction = ShootHere.position - spawnedBullet.transform.position;
            direction = direction * 0.1f;
            bulletScript.direction = direction;

            spawnedBullet = null;
        }

        Debug.Log(context.performed);

    }

}

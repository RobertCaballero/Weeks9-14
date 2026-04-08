using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform SpawnPoint;
    public Transform ShootHere;

    private GameObject spawnedBullet;
    private Coroutine MoveBullet;
   
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedBullet != null)
        {
           spawnedBullet.transform.position = SpawnPoint.position;
        }

    }

    public void Interact(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
           spawnedBullet = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);

        }

    }
    public void OnClick(InputAction.CallbackContext context)
    {

        if (context.performed && spawnedBullet !=null)
        {

            MoveBullet = StartCoroutine(Move());

        }

        Debug.Log(context.performed);

    }


    private IEnumerator Move()
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();

        Vector3 direction = ShootHere.position - spawnedBullet.transform.position;
        bulletScript.direction = direction;

        spawnedBullet = null;

        yield return null;
    }



}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBullet : MonoBehaviour
{

    public GameObject bullet; //Variable of the bullet that is going to be spawned
    public Transform SpawnPoint; //Variable of the spawn point where the bullet is going to be spawned.
    public Transform ShootHere; //Variable of the point where the bullet is going to look towards when it is shot.

    private GameObject spawnedBullet; //Variable of the bullet that is spawned, this is used to move the bullet after it is spawned and to change its speed with the red and green buttons
    private Coroutine MoveBullet; //Variable of the coroutine that moves the bullet.




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedBullet != null) //If the spawned bullet is not null, set its position to the spawn point, this is used so the bullet keeps following the spawn point until it's shot. The spawnpoint it's attach to the players.
        {
           spawnedBullet.transform.position = SpawnPoint.position; //Set the position of the spawned bullet to the position of the spawn point.
        }

    }

    public void Interact(InputAction.CallbackContext context) //Use the player input action for it later being able to map it into the Interact action.
    {

        if (context.performed) //When perfomed is true, spawn the bullet at the spawn point, this is used to spawn the bullet when the interact button is pressed and doesn't take into account when the key is held down or released. 
        {
           spawnedBullet = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);//Spawn the bullet at the position of the spawn point and with no rotation.

        }

    }
    public void OnClick(InputAction.CallbackContext context) //Use the player input action for it later being able to map it into the Click action, this is used to shoot the bullet when the click button is pressed.
    {

        if (context.performed && spawnedBullet !=null) //When perfomed and spawnedBullet is not null, start the Move coroutine. 
        {
            MoveBullet = StartCoroutine(Move()); //Start the coroutine.
        }

        Debug.Log(context.performed);

    }


    private IEnumerator Move() //Courotine that moves the bullet, this is used to move the bullet towards the point we named ShootHere.
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>(); //Get the Bullet script from the spawnedBullet, this is used to access the direction variable in the Bullet script and set it to the direction of the bullet.

        Vector3 direction = ShootHere.position - spawnedBullet.transform.position; //Calculate the direction from the spawned bullet to the ShootHere point

        spawnedBullet = null; //Set the spawnedBullet to null

        yield return null;//Close the coroutine.
    }



}

using UnityEngine;

public class ButtonsSpeed : MonoBehaviour
{
    private float speed = 3f; //Variable of speed

    public GameObject spawnedBullet; //Variable of the bullet that is spawned

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseSpeed() //Method to increase the speed of the bullet
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>(); //Get the Bullet script component from the spawned bullet

        bulletScript.speed += speed; //Increase the speed of the bullet by the value of speed, in this case would be 3f
    }

    public void DecreaseSpeed() //Method to decrease the speed of the bullet
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>(); //Get the Bullet script component from the spawned bullet

        bulletScript.speed -= speed; //Decrease the speed of the bullet by the value of speed, in this case would be -3f

        if (bulletScript.speed < 0f) //If the speed is less than 0 set it back to 1, this stops the speed to reach a negative value. 
        {
            bulletScript.speed = 1f;
        }
    }
}

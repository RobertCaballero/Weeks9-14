
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed; //Variable of speed of the bullet
    public float timer; //Variable of timer to destroy the bullet after a certain time
    public float bullettimer; //Variable of timer to stop the rotation of the bullet after a certain time
    public Coroutine Rotate; //Variable of the coroutine to rotate the bullet

    public Sprite SmallBullet; //Variable of the sprite of the smallbullet
    public Sprite BigBullet; //Variable of the sprite of the bigbullet
    public Sprite catBullet; //Variable of the sprite of the catbullet
    public Sprite dogBullet; //Variable of the sprite of the dogbullet




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Rotate = StartCoroutine(RotatingBullet()); //Start the coroutine to rotate the bullet when the bullet is created

    }

    // Update is called once per frame
    void Update()
    {

        

        timer += timer * Time.deltaTime; //Increase the timer by Time.deltaTime, meaning it increses every second

        bullettimer += bullettimer * Time.deltaTime; //Increase the bullettimer by Time.deltaTime, meaning it increses every second

        transform.position += direction * speed * Time.deltaTime; //Move the bullet in the direction of the direction variable, multiplied by the speed variable and Time.deltaTime to make it move every second

        Vector3 CameraSize = Camera.main.WorldToViewportPoint(transform.position); //Set the position of the bullet in the viewport of the camera.

            if (CameraSize.x > 1 || CameraSize.x < 0 || CameraSize.y > 1 || CameraSize.y < 0 || timer >= 15f) //If the bullet is outside of the viewport of the camera or if the timer is greater than or equal to 15 seconds, destroy the bullet
        {

                Destroy(gameObject);
                timer = 0f; //Reset the timer to 0
        }

        if (bullettimer >= 8f) //If the bullettimer is greater than or equal to 8 seconds, stop the coroutine to rotate the bullet and reset the bullettimer to 0
        {
            StopCoroutine(Rotate);
            bullettimer = 0f; //Reset the bullettimer to 0
        }
    }

    public IEnumerator RotatingBullet() //Coroutine to rotate the bullet towards the mouse position
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());  //Get the mouse position in world space
        Vector2 direction = mousePos - (Vector2)transform.position; //Calculate the direction from the bullet to the mouse position

        transform.up = direction; //Set the up direction of the bullet to the direction from the bullet to the mouse position, making the bullet rotate towards the mouse position

        yield return null; //End of the coroutine
    }

    public void ChangeSpriteSmall() //Function to change the sprite of the bullet
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = SmallBullet; //Change the sprite of the bullet to the smallbullet sprite
    }

    public void ChangeSpriteBig() //Function to change the sprite of the bullet
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = BigBullet; //Change the sprite of the bullet to the bigbullet sprite
    }

    public void ChangeSpriteCat() //Function to change the sprite of the bullet
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = catBullet; //Change the sprite of the bullet to the catbullet sprite
    }

    public void ChangeSpriteDog() //Function to change the sprite of the bullet
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = dogBullet; //Change the sprite of the bullet to the dogbullet sprite
    }
}

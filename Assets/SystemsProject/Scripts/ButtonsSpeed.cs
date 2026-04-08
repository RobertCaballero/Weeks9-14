using UnityEngine;

public class ButtonsSpeed : MonoBehaviour
{
    private float speed = 3f;

    public GameObject spawnedBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseSpeed()
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();

        bulletScript.speed += speed;
    }

    public void DecreaseSpeed()
    {
        Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();

        bulletScript.speed -= speed; 

        if (bulletScript.speed < 0f)
        {
            bulletScript.speed = 1f;
        }
    }
}

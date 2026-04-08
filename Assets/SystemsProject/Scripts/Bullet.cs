using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed;
    public float timer;
    public float bullettimer;
    public Coroutine Rotate;

    public Sprite SmallBullet;
    public Sprite BigBullet;
    public Sprite catBullet;
    public Sprite dogBullet;
    
  
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Rotate = StartCoroutine(RotatingBullet());

        timer += timer * Time.deltaTime;

        bullettimer += bullettimer * Time.deltaTime;

            transform.position += direction * speed * Time.deltaTime;

            Vector3 CameraSize = Camera.main.WorldToViewportPoint(transform.position);


            if (CameraSize.x > 1 || CameraSize.x < 0 || CameraSize.y > 1 || CameraSize.y < 0 || timer >= 15f)
            {

                Destroy(gameObject);
                timer = 0f;
            }

        if (bullettimer >= 5f)
        {
            StopCoroutine(RotatingBullet());
            bullettimer = 0f;
        }
    }

    public IEnumerator RotatingBullet()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePos - (Vector2)transform.position;

        transform.up = direction;

        yield return null;
    }

    public void ChangeSpriteSmall()
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = SmallBullet;
    }

    public void ChangeSpriteBig()
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = BigBullet;
    }

    public void ChangeSpriteCat()
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = catBullet;
    }

    public void ChangeSpriteDog()
    {
        SpriteRenderer bulletskin = GetComponent<SpriteRenderer>();
        bulletskin.sprite = dogBullet;
    }
}

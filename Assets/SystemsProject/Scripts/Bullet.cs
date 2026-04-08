using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x > 1 || screenPos.x < 0 ||screenPos.y > 1 || screenPos.y < 0)
        {
            Destroy(gameObject);
        }

    }

   


}

using UnityEngine;

public class player : MonoBehaviour
{
    public int Health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
        {
            transform.position = Vector3.zero;
        }
    }


    public void TakingDamage(int damage)
    {
        Health -= damage;
    }
}
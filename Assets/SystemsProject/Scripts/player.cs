using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public int Health = 10; //Variable of health


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakingDamage(int damage) //Method that will take damage of the player by a certain amount, in this case the damage variable
    {
        Health -= damage; //Decrease the health of the player by the value of damage

        if (Health <= 0) //If the health is less than or equal to 0, reset the player
        {
            transform.position = Vector3.zero; //Reset the position of the player to coordinates (0,0,0), center of the scene
            Health = 10;//Restore health back to 10
        }

    }

    

}
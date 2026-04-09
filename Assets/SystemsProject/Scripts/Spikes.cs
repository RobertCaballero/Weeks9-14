using UnityEngine;
using UnityEngine.Events;

public class Spikes : MonoBehaviour
{

    public int damage; //Variable of the damage.
    public player player; //Variable of the player!
    public Color Damaged; //Variable of the colour of the player when it is damaged.
    public Color NotDamaged; //Variable of the colour of the player when it is not damaged

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage() //Method that applies the damage to the player.
    {
        player.TakingDamage(damage); //using the players script, call the TakingDamage method.
    }

    public void ChangePlayerColour () //Method that changes the colour of the player when it is damaged.
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>(); //Get the SpriteRenderer component from the player, this is used to change the colour of the player when it is damaged.
        NotDamaged = playerRenderer.color; //Set the NotDamaged variable to the current colour of the playerayer
        playerRenderer.color = Damaged; //Set the color of the player to the Damaged color.

    }

    public void ResterPlayerColour ()//Method that resets the colour of the player when it is not damaged.
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>(); //Get the SpriteRenderer component from the player, this is used to change the colour of the player when it is not damaged.
        playerRenderer.color = NotDamaged; //Set the color og the player to the NotDamaged color!
    }
}

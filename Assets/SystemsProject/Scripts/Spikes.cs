using UnityEngine;
using UnityEngine.Events;

public class Spikes : MonoBehaviour
{

    public int damage;
    public player player;
    public Color Damaged;
    public Color NotDamaged;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage()
    {
        player.TakingDamage(damage);
    }

    public void ChangePlayerColour ()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        NotDamaged = playerRenderer.color;
        playerRenderer.color = Damaged;

    }

    public void ResterPlayerColour ()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        playerRenderer.color = NotDamaged;
    }
}

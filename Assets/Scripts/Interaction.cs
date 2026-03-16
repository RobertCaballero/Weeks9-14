using UnityEngine;

public class Interaction : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    int index = 0;
    public Sprite [] Player2;
    public float Increment = 1f;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(index);


        if (index == Player2.Length-1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        spriteRenderer.sprite = Player2[index];

    }

    public void ChangeSprite()
    {

        if (index == Player2.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        spriteRenderer.sprite = Player2[index];
    }
}

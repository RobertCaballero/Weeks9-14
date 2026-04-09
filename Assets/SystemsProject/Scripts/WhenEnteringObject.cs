using UnityEngine;
using UnityEngine.Events;

public class WhenEnteringObject : MonoBehaviour
{
    public Transform Player; //Variable of the player, this is used to check if the player is inside the object or not.
    public UnityEvent OnEnter; //Unity event that will be used for when the players enters the object or object in our scene.
    public UnityEvent OnExit; //Unity event that will be used for when the players exits the object or object in our scene.
    private SpriteRenderer objectRenderer; //Variable of the SpriteRenderer component of the object, this is used to get the bounds of the object to check if the player is inside or not.
    private bool wasInObject = false; //Boolean variable to check if the player was inside the object in the last frame. 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>(); //Get the SpriteRenderer component from the object.
    }

    // Update is called once per frame
    void Update()
    {
        bool isInObject = (objectRenderer.bounds.Contains(Player.transform.position)); //Check if the bounds of the object contains the position of the player.

        if (isInObject && wasInObject == false ) //If wasInObject is false and isInObject is true, the player is inside the object!
        {
            wasInObject = true; //Set wasInObject to true, so it doesn't trigger the event again until the player exits and enters again.
            OnEnter.Invoke(); //Invoke the OnEnter event, this is used to activate any event mapped into it.

            Debug.Log("I'm Inside");

        }
        else if(!isInObject && wasInObject) //If wasInObject is true and isInObject is false, the player is outside the object!
        {
            wasInObject = false; //Set wasInObject to false, so it doesn't trigger the event again until the player enters and exits again.
            OnExit.Invoke(); //Invoke the OnExit event, this is used to activate any event mapped into it.
            Debug.Log("I'm Outside");
        }
    }
}

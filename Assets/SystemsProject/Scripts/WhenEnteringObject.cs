using UnityEngine;
using UnityEngine.Events;

public class WhenEnteringObject : MonoBehaviour
{
    public Transform Player;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    private SpriteRenderer objectRenderer;
    private bool wasInObject = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isInObject = (objectRenderer.bounds.Contains(Player.transform.position));

        if(isInObject && wasInObject == false )
        {
            wasInObject = true;
            OnEnter.Invoke();

            Debug.Log("I'm Inside");

        }
        else if(!isInObject && wasInObject)
        {
            wasInObject = false;
            OnExit.Invoke();
            Debug.Log("I'm Outside");
        }
    }
}

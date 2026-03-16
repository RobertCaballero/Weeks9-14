using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Gun : MonoBehaviour
{
    public GameObject Body;
    public Vector2 Look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Body = GetComponent<ConStrollerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Look);

        ControllerInput look = Body.GetComponent<ControllerInput>();

        look.LookInput = Look;

       transform.up = Look;
    }
}

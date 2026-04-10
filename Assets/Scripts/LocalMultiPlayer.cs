using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayer : MonoBehaviour
{

    public Vector2 moveDirection;
    public float moveSpeed;
    public LocalMultiplayerManager manager;

    public Vector3 playerScale;
    public AnimationCurve scaleCurve;

    float progress;
    float duration = 1;
    float time;

    Coroutine attacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        //Debug.Log(playerScale);
    }


    public void OnMove (InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


    public void OnAttack (InputAction.CallbackContext context)
    {
        

        if (context.performed)
        {

            if (attacking != null)
            {
                StopCoroutine(attacking); 
            }

            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);

            attacking = StartCoroutine(Attacking());

        
        }

        Debug.Log("Attack: " + context.phase);

    }

    private IEnumerator Attacking()
    {
       
        while (time < duration)
        {
            time += Time.deltaTime;

            progress = scaleCurve.Evaluate(time);

            playerScale = new Vector3(1, progress, 1);

            transform.localScale = playerScale;

            if (time > duration)
            {
                Debug.Log("stop");

                StopCoroutine(attacking);

                time = 0;
               
            }

            yield return null;

        }
    }

}

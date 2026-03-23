using UnityEngine;
using System.Collections;

public class MovePlayer2 : MonoBehaviour
{
    public AnimationCurve movePlayer;
    public float duration;

    public Transform StartPos;
    public Transform EndPos;

    private Coroutine PlayerMoves;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator PlayerMoveUpdate()
    {
        float progress = 0f;

        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localPosition = Vector2.Lerp(StartPos.position, EndPos.position, movePlayer.Evaluate(progress / duration));    
            yield return null;
 
        }

    }

    //private IEnumerator PlayerMoveBack()
    //{
    //    float progress = 0f;

    //    while (progress < duration)
    //    {
    //        progress += Time.deltaTime;
                //transform.localPosition = Vector2.Lerp(EndPos.position, StartPos.position, movePlayer.Evaluate(progress / duration));
//        yield return null;

//    }

//}

public void OnMovePress()
    {
        PlayerMoves = StartCoroutine(PlayerMoveUpdate());

    }
}

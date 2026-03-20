using System.Collections;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public AnimationCurve movePlayer;
    public float duration;

    private float progress = 0f;

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
            transform.localPosition = movePlayer.Evaluate(progress / duration) * Vector3.one;
            yield return null;
        }
    }

    public void OnMovePress ()
    {
        PlayerMoves = StartCoroutine(PlayerMoveUpdate());
    }
}

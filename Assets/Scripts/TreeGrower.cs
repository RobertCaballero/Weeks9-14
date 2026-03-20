using System;
using System.Collections;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{

    public AnimationCurve growCurve;
    public Transform branchesTransform;
    public float maxSpawnDistance;

    public float duration;

    public GameObject applePrefab;
    public float appleGrowDuration;

    private Coroutine treeGrowCoroutine;
    private Coroutine appleCoroutine;

    //private float progress = 0f;
    //private bool isGrowing = false;
    //private bool isAppleGrowing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isGrowing)
        //{
            //progress += Time.deltaTime;
            //transform.localScale = growCurve.Evaluate(progress/duration) * Vector3.one;

            //if (progress > duration)
            //{
            //    isGrowing = false;
            //    progress = 0f;
            //    isAppleGrowing = true;
            //}
        //}

        //if(isAppleGrowing)
        //{

        //}

    }

    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0f;
        //Debug.Log("Progress["+progress.ToString()+"] Duration["+duration.ToString()+"]");
        //The contents of the while loop run while the condition is true
        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;

            //Relinquishes control of Unity so that everything else can run
            //For the rest of this frame (Stop this frame, continue next one)
            yield return null;

            Debug.Log("How much time has it passed" + Time.deltaTime);
        }

        //Relinquis control for unity until the apple has finished growing
        //yield return new WaitForSeconds(appleGrowDuration);

         appleCoroutine = StartCoroutine(AppleGrowUpdate());

        //Relinquish control of Unity until the coroutine for the apple
        //has finished executing
        yield return appleCoroutine;

        appleCoroutine = StartCoroutine(AppleGrowUpdate());
        yield return appleCoroutine;

        StartCoroutine(AppleGrowUpdate());

    }

    private IEnumerator AppleGrowUpdate()
    {
        Vector3 spawnPosition = branchesTransform.position;
        spawnPosition += (Vector3)UnityEngine.Random.insideUnitCircle * maxSpawnDistance;

        GameObject spawnedApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        spawnedApple.transform.localScale = Vector3.zero;
        float progress = 0f;

        while (progress < appleGrowDuration)
        {
            progress += Time.deltaTime;

            spawnedApple.transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;

            //Relinquishes control of Unity so that everything else can run
            //For the rest of this frame (Stop this frame, continue next one)
            yield return null;
        }
    }

    public void OnGrowPress () 
    {
        //isGrowing=true;
        treeGrowCoroutine = StartCoroutine(TreeGrowUpdate());
    
    }

    public void OnStopPress()
    {
        //

        if (treeGrowCoroutine != null)
        {
            StopCoroutine(treeGrowCoroutine);
        }
        if(appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
        
        
    }
}

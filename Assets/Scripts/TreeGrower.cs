using System;
using System.Collections;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{

    public AnimationCurve growCurve;
    public Transform branchesTransform;
    public float maxSPawnDistance;

    public float duration;

    public GameObject applePrefab;
    public float appleGrowDuration;

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

        //The contents of the while loop run while the condition is true
        while (progress > duration)
        {
            progress += Time.deltaTime;
            transform.localScale = growCurve.Evaluate(progress / duration) * Vector3.one;

            //Relinquishes control of Unity so that everything else can run
            //For the rest of this frame (Stop this frame, continue next one)
            yield return null;

            Debug.Log("How much time has it passed" + Time.deltaTime);
        }

        StartCoroutine(AppleGrowUpdate());
        StartCoroutine(AppleGrowUpdate());
        StartCoroutine(AppleGrowUpdate());

    }

    private IEnumerator AppleGrowUpdate()
    {
        GameObject spawnedApple = Instantiate(applePrefab, transform.position, Quaternion.identity);
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
        StartCoroutine(TreeGrowUpdate());
    
    }
}

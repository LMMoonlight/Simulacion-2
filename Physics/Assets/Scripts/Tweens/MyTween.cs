using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTween : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition = Vector3.one;

    [Header("Time Duration")]
    [SerializeField] float duration = 1;
    [SerializeField] [Range(0, 1)] float t = 1;

    [SerializeField] private AnimationCurve ease;
    [SerializeField] private Transform targetPos;

    bool isPlaying = false;
    private float totalTime = 0;
    void Start()
    {
        startPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            totalTime = 0;
            isPlaying = true;
            startPosition = transform.position;
        }

        if (!isPlaying) return;

        t = totalTime/duration;
        totalTime += Time.deltaTime;
        transform.position = Vector3.LerpUnclamped(startPosition, targetPos.position, ease.Evaluate(t));
       
        if (t >= 1)
        {
            isPlaying = false;
            Debug.Log("Completed");
        }
    }

    private float Cubic(float x)
    {
        return x * x * x;
    }

}

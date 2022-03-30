using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinDraw : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int nSamples = 5;

    [SerializeField] [Range(0, 1)] float separationFactor = 1;
    [SerializeField] [Range(0, 10)] float y = 1;
    [SerializeField] [Range(0, 10)] float noise = 1;
    [SerializeField] [Range(0, 10)] float t = 1;
    [SerializeField] float a = 0;

    void Start()
    {
        for (int i = 0; i < nSamples; i++)
        {
         Instantiate(prefab, transform);
        }   
    }

    // Update is called once per frame
    void Update()
    {   
        int i = 0;
        a += Time.deltaTime;
        foreach (Transform child in transform)
        {
            float x = i*separationFactor;
            child.localPosition = new Vector3(x, Mathf.Sin(2*Mathf.PI*(x+a)/t)*y/*+Mathf.Sin(noise*x)*/, 0);
            ++i;
        }
    }
}

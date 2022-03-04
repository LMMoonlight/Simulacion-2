using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polars : MonoBehaviour
{

    [SerializeField] float radious = 1, tetha = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawPolar(float radious, float tetha)
    {
        Vector3 cartesian = new Vector3(Mathf.Cos(tetha), Mathf.Sign(tetha));
        Debug.DrawLine(Vector3.zero, cartesian);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polars : MonoBehaviour
{

    [SerializeField] float radious = 1, theta = 0;
    [SerializeField] Vector2 polarCord; //X is radious, Y is theta.
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        polarCord.y += 0.01f;
        DrawPolar(polarCord);
    }

    private void DrawPolar(Vector2 polarCord)
    {
        Vector3 cartesian = PolarToCartesian(polarCord);
        Debug.DrawLine(Vector3.zero, cartesian, Color.yellow);
    }

    private Vector3 PolarToCartesian(Vector2 polar)
    {

        Vector3 cartesian = new Vector3(Mathf.Cos(polarCord.y), Mathf.Sin(polarCord.y));
        cartesian *= polarCord.x;
        return cartesian;       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polars : MonoBehaviour
{
    [SerializeField] Vector2 polarCord; //X is radious, Y is theta.

    [Header("Angular")]
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAceleration;

    [Header("Radial speed")]
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAceleration;

    [Header("Borders")]
    [SerializeField] float xBorder;
    [SerializeField] float yBorder;

    [SerializeField] GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        polarCord.y += 0.01f;
        polarCord.x += 0.001f;

        RadialMovement();
        sphere.transform.position = PolarToCartesian(polarCord);        
        
        DrawPolar(polarCord);
        CheckCollision();
    }

    private void RadialMovement()
    {
        radialSpeed += radialAceleration * Time.deltaTime;
        polarCord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAceleration * Time.deltaTime;
        polarCord.y += angularSpeed * Time.deltaTime;
    }


    private void CheckCollision()
    {
        //cambiarlo mejor a que chequee si el radio es mayor o igual a los bordes.

        if (sphere.transform.position.x >= xBorder || sphere.transform.position.x <= -xBorder ||
            sphere.transform.position.y >= yBorder || sphere.transform.position.y <= -yBorder)
        {
            radialSpeed *= -1;
        }
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

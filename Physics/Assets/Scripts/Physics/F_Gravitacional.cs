using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class F_Gravitacional : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] bool canMove;
    Vector3 displacement;
    [SerializeField] Vector3 velocity, aceleration, damping;
    Transform trans;

    [Header("Game borders")]
    [SerializeField] float yBorder;
    [SerializeField] float xBorder;

    public float myMass;
    [SerializeField] float maxForce;

    [SerializeField] GameObject otherSphere;
    F_Gravitacional otherFG;
    float otherMass;


    Vector3 distance, gForce;

    void Start()
    {
        trans = GetComponent<Transform>();
        otherFG = otherSphere.GetComponent<F_Gravitacional>();
        otherMass = otherFG.myMass;       
    }

    void Update()
    {
        //ApplyForce(new Vector3(1, 0, 0));

        distance = otherSphere.transform.position - transform.position;;
        gForce = ((myMass * otherMass) / (distance.magnitude * distance.magnitude)) * distance.normalized;
        if (gForce.magnitude > maxForce) gForce = gForce.normalized * maxForce;
        ApplyForce(gForce);
        
        if(canMove) Move();
        CheckCollision();
        //ApplyForce(Vector3.zero);

        aceleration = Vector3.zero;
    }

    public void Move()
    {
        velocity += aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + displacement;

        /*aceleration.Draw(transform.position, Color.blue);
        velocity.Draw(transform.position, Color.green);
        transform.position.Draw(Color.red);*/
    }

    private void CheckCollision()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)
        {
            if (transform.position.x <= -xBorder) trans.position = new Vector3(-xBorder, trans.position.y, 0);
            else if (transform.position.x >= xBorder) trans.position = new Vector3(xBorder, trans.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x - damping.x;
            //aceleration.x *= -1;
        }
        else if (transform.position.y >= yBorder || transform.position.y <= -yBorder)
        {
            if (transform.position.y <= -yBorder) trans.position = new Vector3(transform.position.x, -yBorder, 0);
            else if (transform.position.y >= yBorder) trans.position = new Vector3(transform.position.x, yBorder, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y - damping.y;
            //aceleration.y *= -1;
        }
    }

    private void ApplyForce(Vector3 force)
    {
        aceleration += force / myMass;
    }
}

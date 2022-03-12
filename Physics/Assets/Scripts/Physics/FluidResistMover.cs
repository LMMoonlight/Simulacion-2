using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class FluidResistMover : MonoBehaviour
{
    //[SerializeField]
    Vector3 displacement;
    [SerializeField] Vector3 velocity, aceleration, damping;

    Vector3 weight;
    float frontalArea;
    Transform trans; 

    [Header("Game borders")]
    [SerializeField] float yBorder;
    [SerializeField] float xBorder;

    [SerializeField] float mass;
    [SerializeField] float gravity;
    [SerializeField] [Range(0, 1)] float co_U;
    private void Start()
    {
        trans = GetComponent<Transform>();
        frontalArea = transform.localScale.x;
        weight = mass * new Vector3(0, gravity, 0);
    }
    private void Update()
    {
        //ApplyGravity(new Vector3(0, gravity, 0));
        //ApplyForce(new Vector3(0, 1, 0));
        //if(trans.position.y <= 0) ApplyForce(-mu * weight.magnitude * velocity.normalized);
        ApplyForce(weight);
        if (transform.position.y <= 0)
        {
            float fluidResistanceMagnitude = -0.5f * velocity.magnitude * velocity.magnitude * frontalArea * co_U;
            ApplyForce(fluidResistanceMagnitude * velocity.normalized);
        }
        Move();
        CheckCollisions();

        aceleration = Vector3.zero;

    }
    public void Move()
    {
        // accelaration = referencia.position - trans.position;
        velocity = velocity + (aceleration * Time.deltaTime);
        displacement = velocity * Time.deltaTime;
        base.transform.position = base.transform.position + displacement;
        //transform.position = transform.position + new Vector3(desplacement1.x, desplacement1.y, 0);

        aceleration.Draw(base.transform.position, Color.red);
        velocity.Draw(base.transform.position, Color.cyan);
        base.transform.position.Draw(Color.white);
    }

    private void CheckCollisions()
    {
        //if (transform.position.x >= width || transform.position.x <= -width) velocity.X = velocity.X * -1;
        //if (transform.position.y >= height || transform.position.y <= -height) velocity.Y = velocity.Y * -1; 
        if (base.transform.position.x >= xBorder || base.transform.position.x <= -xBorder)
        {
            if (base.transform.position.x <= -xBorder) transform.position = new Vector3(-xBorder, transform.position.y, 0);
            else if (base.transform.position.x >= xBorder) transform.position = new Vector3(xBorder, transform.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x - damping.x;
        }
        if (base.transform.position.y >= yBorder || base.transform.position.y <= -yBorder)
        {
            if (base.transform.position.y <= -yBorder) transform.position = new Vector3(transform.position.x, -yBorder, 0);
            else if (base.transform.position.y >= yBorder) transform.position = new Vector3(transform.position.x, yBorder, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y - damping.y;
        }
    }
    void ApplyForce(Vector3 force) { aceleration += force / mass; }

    void ApplyGravity(Vector3 gravity) { aceleration += mass * gravity; }
}

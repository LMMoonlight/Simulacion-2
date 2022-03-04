using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class Mover : MonoBehaviour
{
    //[SerializeField]
    Vector3 displacement;
    [SerializeField] Vector3 velocity, aceleration, damping;
    Transform trans;

    [Header("Game borders")]
    [SerializeField] float yBorder;
    [SerializeField] float xBorder;

    [SerializeField] float mass;
    [SerializeField] float gravity;
    [SerializeField] [Range(0, 1)] float co_U;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        ApplyGravity(new Vector3(0, gravity, 0));
        ApplyForce(new Vector3(1, 0, 0));
        if(trans.position.y <= 0) ApplyFriction(velocity);
        Move();
        CheckCollision();

        aceleration = Vector3.zero;
    }

    public void Move()
    {
        velocity += aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + displacement;

        aceleration.Draw(transform.position, Color.blue);
        velocity.Draw(transform.position, Color.green);
        transform.position.Draw(Color.red);
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
        aceleration += force / mass;
    }

    private void ApplyGravity(Vector3 gravity)
    {
        aceleration += mass * gravity;
    }

    private void ApplyFriction(Vector3 velocity)
    {
        aceleration = -1 * co_U * velocity.normalized;
    }
}

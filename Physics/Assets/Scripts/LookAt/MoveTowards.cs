using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    Vector3 displacement, diference, aceleration;
    [SerializeField] float velocity;

    Vector3 vVelocity;
    float rad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        MoveAceler();
    }

    public void Move()
    {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;

        diference = targetPos - transform.position;

        vVelocity = diference.normalized;
        displacement = vVelocity * Time.deltaTime* velocity;
        transform.position = transform.position + displacement;

        //transform.position += targetPos * velocity;

        //transform.position = Vector2.Lerp(transform.position, targetPos, 0.002f);
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);
    }

    public void MoveAceler()
    {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;

        diference = targetPos - transform.position;
        aceleration = diference;
        vVelocity += aceleration * Time.deltaTime;
        transform.position += vVelocity *Time.deltaTime;

        rad = Mathf.Atan2(vVelocity.y, vVelocity.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, rad * Mathf.Rad2Deg);
        aceleration = Vector3.zero;
    }
}

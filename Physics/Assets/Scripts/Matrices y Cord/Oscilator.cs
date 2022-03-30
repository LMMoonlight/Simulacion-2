using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

    [SerializeField] float x = 0;
    [SerializeField] float y = 0;
    float calc;

    private void Start()
    {
        x = Random.Range(-5, 5);
        y = Random.Range(-5, 5);
    }

    void Update()
    {
        calc = Mathf.Sin(Time.time);
        transform.position = new Vector3(calc*x, calc * y, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        //float slope = mousePos.y / mousePos.x;
        //float radians = Mathf.Atan(slope);
        Vector3 diference = mousePos - transform.localPosition;
        float radians = Mathf.Atan2(diference.y, diference.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        Debug.DrawLine(Vector3.zero, transform.position);
        return worldPos;
    }
}

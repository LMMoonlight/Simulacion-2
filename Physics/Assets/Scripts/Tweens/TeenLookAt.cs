using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeenLookAt : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {
        var seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        GetComponent<Camera>().DOFieldOfView(70, 0.5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasicMover : MonoBehaviour
{
    bool isPlaying = false;
    [SerializeField] Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(Vector3.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Move(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Move(Vector3.back);
    }

    private void Move(Vector3 displacement)
    {
        float duration = 0.3f;
        Vector3 endPosition = transform.position + displacement;
        Vector3 midPosition = Vector3.Lerp(transform.position, endPosition, 0.5f);
        midPosition.y = 2;

        var traslationSequence = DOTween.Sequence();
        traslationSequence.Append(transform.DOMove(midPosition, duration * 0.5f));
        traslationSequence.Append(transform.DOMove(endPosition, duration*0.5f));
        traslationSequence.Append(camera.DOShakePosition(0.1f));

        //transform.DOMove(endPosition, duration);

        var squashSequence = DOTween.Sequence();
        squashSequence.Append(transform.DOScaleY(0.2f, duration * 0.3f));
        squashSequence.Append(transform.DOScaleY(1f, duration * 0.7f));

        isPlaying = true;
        traslationSequence.onComplete += OnMoveComplete;
    }
    
    private void OnMoveComplete()
    {
        isPlaying = false;
    }
}

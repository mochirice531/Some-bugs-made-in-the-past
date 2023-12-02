using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget_j : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position + offset;

        if (Input.GetKey("v"))
        {
            gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}

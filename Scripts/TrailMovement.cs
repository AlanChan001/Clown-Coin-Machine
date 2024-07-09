using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    Vector2 startPos;
    float x;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 trailVector;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * movementSpeed;
        transform.position = startPos + trailVector * Mathf.Sin(x);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInserterMovement: MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    private Vector3 change;
    private Rigidbody2D myRigidbody;
    private float inserterX = 0f;
    private float x;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change.x = Input.GetAxisRaw("Horizontal") *Time.deltaTime * moveSpeed;
        moveCoinInserter();
    }

    void moveCoinInserter()
    {
        inserterX += change.x;
        inserterX = Mathf.Clamp(inserterX, minX, maxX);        
        transform.position = new Vector3(inserterX, transform.position.y, transform.position.z);
    }

   
}

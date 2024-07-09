using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationalRate = 10f;
    private float rotateZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }

    void rotate()
    {
         rotateZ += rotationalRate * Time.deltaTime;
         transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotateZ) ;
        
    }
}

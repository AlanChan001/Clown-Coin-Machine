using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRecycle : MonoBehaviour
{
    [SerializeField] Collider2D myCollider;
    public bool isTouching = false;
    private float recycleTime;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        recycleTime =BarCoinSensor.Instance.recycleTime;
    }

    
    void Update()
    {
        if (BarCoinSensor.Instance.isRecycling)
        {
            Invoke("Destroy", recycleTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            isTouching = true;
        }

    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }


}

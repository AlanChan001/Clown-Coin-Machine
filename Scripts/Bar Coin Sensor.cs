using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCoinSensor : Singleton<BarCoinSensor>
{

    public bool isRecycling = false;
    public float recycleTime { get; private set; } = 3f;
    private Collider2D myCollider;
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        
 
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "coin" && other.GetComponent<CoinRecycle>().isTouching)
        {
            StartCoroutine(recycleRoutine(recycleTime));
        }

    }

    public IEnumerator recycleRoutine(float recycleTime)
    {
        isRecycling = true;
        myCollider.enabled = false;
        myRenderer.enabled = false;
        yield return new WaitForSeconds(recycleTime);
        myCollider.enabled = true;
        myRenderer.enabled = true;
        isRecycling = false;
    }
}

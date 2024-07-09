using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    float x;
    float y;
    [SerializeField]float changingRate;

    // Update is called once per frame
    void Update()
    {
        changeSize();
    }

    void changeSize()
    {
        x += Time.deltaTime * changingRate;
        y = Mathf.Clamp(Mathf.Sin(x), -1, 1);
        transform.localScale =new Vector3(y, y, y);

    }
}

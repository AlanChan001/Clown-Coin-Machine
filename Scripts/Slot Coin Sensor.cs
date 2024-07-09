using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCoinSensor : MonoBehaviour
{
    public int slotNumber;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            GetComponentInParent<CoinScore>().slot[slotNumber] = true;
        }
    }

}

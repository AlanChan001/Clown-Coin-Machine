using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{
    public int coinNumber = 30;

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Number of Coins: " + coinNumber;
    }
}

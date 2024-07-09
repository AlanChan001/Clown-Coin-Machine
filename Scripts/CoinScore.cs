using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public bool[] slot;
    public bool[] countedSlot;
    [SerializeField] GameObject horizontalBar;
    [SerializeField] TextMeshProUGUI cashoutText;
    [SerializeField] TextMeshProUGUI coinNumberText;
    public int cashoutNumberOfCoins = 0;
    private float recycleTime;

    void Start()
    {
        slot = new bool[8];
        countedSlot = new bool[8];
        recycleTime = BarCoinSensor.Instance.recycleTime;
    }

    // Update is called once per frame
    void Update()
    {
        countedSlot[0] = false;
        countedSlot[1] = false;
        countedSlot[2] = false;
        countedSlot[3] = false;
        countedSlot[4] = false;
        countedSlot[5] = false;
        countedSlot[6] = false;
        countedSlot[7] = false;
        
        cashoutCoinCount();
        if (horizontalBar.GetComponent<BarCoinSensor>().isRecycling)
        {
            slot[0] = false;
            slot[1] = false;
            slot[2] = false;
            slot[3] = false;
            slot[4] = false;
            slot[5] = false;
            slot[6] = false;
            slot[7] = false;
            countedSlot[0] = false;
            countedSlot[1] = false;
            countedSlot[2] = false;
            countedSlot[3] = false;
            countedSlot[4] = false;
            countedSlot[5] = false;
            countedSlot[6] = false;
            countedSlot[7] = false;
            
        }
        cashoutText.text = "Cashout For " + cashoutNumberOfCoins + " coins";





    }

    void cashoutCoinCount()
    {
        cashoutNumberOfCoins = 0;
        // row of 8
        if (slot[0] && slot[1] && slot[2] && slot[3] && slot[4] && slot[5] && slot[6] && slot[7] )
        {
            Debug.Log("row of 8");
            countedSlot[0] = true;
            countedSlot[1] = true;
            countedSlot[2] = true;
            countedSlot[3] = true;
            countedSlot[4] = true;
            countedSlot[5] = true;
            countedSlot[6] = true;
            countedSlot[7] = true;
            cashoutNumberOfCoins += (int)Mathf.Pow(2, 8);
        }

        // row of 7
        for (int i = 0; i <= 1; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] && slot[i + 2] && slot[i + 3] && slot[i + 4] && slot[i + 5] && slot[i + 6])
            {
                Debug.Log("row of 7");
                countedSlot[i] = true;
                countedSlot[i+1] = true;
                countedSlot[i+2] = true;
                countedSlot[i+3] = true;
                countedSlot[i+4] = true;
                countedSlot[i+5] = true;
                countedSlot[i+6] = true;
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 7);
            }
        }
        // row of 6
        for (int i = 0; i <= 2; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] && slot[i + 2] && slot[i + 3] && slot[i + 4] && slot[i + 5])
            {
                Debug.Log("row of 6");
                countedSlot[i] = true;
                countedSlot[i + 1] = true;
                countedSlot[i + 2] = true;
                countedSlot[i + 3] = true;
                countedSlot[i + 4] = true;
                countedSlot[i + 5] = true;
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 6);
            }
        }
        // row of 5
        for (int i = 0; i <= 3; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] && slot[i + 2] && slot[i + 3] && slot[i + 4])
            {
                Debug.Log("row of 5");
                countedSlot[i] = true;
                countedSlot[i + 1] = true;
                countedSlot[i + 2] = true;
                countedSlot[i + 3] = true;
                countedSlot[i + 4] = true;
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 5);
            }
        }
        // row of 4
        for (int i = 0; i <= 4; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] && slot[i + 2] && slot[i + 3] )
            {
                Debug.Log("row of 4");
                countedSlot[i] = true;
                countedSlot[i + 1] = true;
                countedSlot[i + 2] = true;
                countedSlot[i + 3] = true;
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 4);
            }
        }
        // row of 3
        for (int i = 0; i <= 5; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] && slot[i + 2] )
            {
                Debug.Log("row of 3");
                countedSlot[i] = true;
                countedSlot[i + 1] = true;
                countedSlot[i + 2] = true;
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 3);
            }
        }
        // row of 2
        for (int i = 0; i <= 6; i++)
        {
            if (countedSlot[i] != true && slot[i] && slot[i + 1] )
            {
                Debug.Log("row of 2");
                cashoutNumberOfCoins += (int)Mathf.Pow(2, 2);

                countedSlot[i] = true;
                countedSlot[i + 1] = true;
                
            }
        }


    }
    public void cashout()
    {
        
        if (cashoutNumberOfCoins > 0 && BarCoinSensor.Instance.isRecycling == false)
        {
            StartCoroutine(BarCoinSensor.Instance.recycleRoutine(recycleTime));
            coinNumberText.GetComponent<CoinText>().coinNumber += cashoutNumberOfCoins;
        }
        
    }
}

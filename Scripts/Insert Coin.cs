using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsertCoin : Singleton<InsertCoin>
{
    [SerializeField] float cooldown;
    [SerializeField] TextMeshProUGUI coinText;
    public GameObject objectToSpawn;
    public Transform SpawnPos;
    private bool readyToInsert = true;
    
    void Update()
    {
        insertCoin();
    }

    public void insertCoin()
    {
        if (Input.GetKeyDown(KeyCode.Space) && readyToInsert && BarCoinSensor.Instance.isRecycling == false)
        {
            coinText.GetComponent<CoinText>().coinNumber--;
            SpawnOject();
            StartCoroutine(CooldownCoroutine(cooldown));
        }
    }

    void SpawnOject()
    {
        Instantiate(objectToSpawn, SpawnPos.position, objectToSpawn.transform.rotation);
    }

    public IEnumerator CooldownCoroutine(float cooldown)
    {
        readyToInsert = false;
        yield return new WaitForSeconds(cooldown);
        readyToInsert = true;
    }
}

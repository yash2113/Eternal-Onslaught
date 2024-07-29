using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    public int currentCoins;

    public CoinPickup coin;


    private void Awake()
    {
        instance = this;
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;

        UIController.instance.UpdateCoins(currentCoins);
    }

    public void DropCoin(Vector3 position, int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(.2f, .1f, 0f), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }
    public void SpendCoins(int coinToSpend)
    {
        currentCoins -= coinToSpend;

        UIController.instance.UpdateCoins(currentCoins);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public void OnEnable()
    {
        FindObjectOfType<CoinManager>().AddCoin(this);
    }
    public void OnDisable()
    {
        FindObjectOfType<CoinManager>().RemoveCoin(this);
    }
    public void PickUpCoin(int point)
    {
        EventManager.OnCoinPickUp.Invoke();
        Destroy(gameObject);
    }

}

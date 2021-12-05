using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public void OnEnable()
    {
        CoinManager.Instance.AddCoin(this);
    }
    public void OnDisable()
    {
        CoinManager.Instance.RemoveCoin(this);
    }
    public void PickUpCoin(int point)
    {
        EventManager.OnCoinPickUp.Invoke();
        Destroy(gameObject);
    }

}

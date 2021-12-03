using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
   private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return ( rigidbody == null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } } //Encapsulation

    // Az kulland���m�z componentleri property haline getirmek sahne y�kleme s�remizi k�saltabilir.
    // ? if rigidbody null rigidbody = GetComponent<Rigidbody>() else rigidbody;

    public float moveSpeed;

    private void FixedUpdate() //Adalet
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Rigidbody.AddForce(input * moveSpeed * Time.deltaTime); // Time.deltaTime normalizasyonu.

        //Rigidbody.velocity = input * moveSpeed * Time.deltaTime; //velocity problem yaratabilir.
    }

    public int point; //De�er ve referanslar tip,metod i�erisinde artt�rd���m�z point bizim buradaki pointimizi artt�rmaz ve her zaman s�f�r d�ner.

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin!= null)
        {
            point++;
            coin.PickUpCoin(point);
        }
    }
}

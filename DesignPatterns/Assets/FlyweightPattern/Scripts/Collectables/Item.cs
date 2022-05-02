using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Event dropped;

    public Event pickUp;

    public Image icon;
    // Start is called before the first frame update
    void Start()
    {
        dropped.Occured(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            
            Destroy(this.gameObject,5);
            
        }
    }
}

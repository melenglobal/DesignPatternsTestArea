using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Drive : MonoBehaviour
{
    public float speed = 10.0f;

    public Slider healthBar;
    
    [SerializeField]
    private GameObject bulletPrefab;
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
           SetBullets();
        }
        
        SetSliderPosition();
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            col.gameObject.SetActive(false);
            
            if (healthBar.value <= 0)
            {   
                Destroy(healthBar.gameObject,0.1f);
                
                Destroy(this.gameObject,0.1f);
            }
            else
            {
                healthBar.value -= 10;
            }
        }
    }

    private void SetBullets()
    {
        GameObject bullet =  Pool.singleton.Get("Bullet");

        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);
        }
    }

    private void SetSliderPosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + new Vector3(0,-130,0);
        healthBar.transform.position = screenPos;
    }
}
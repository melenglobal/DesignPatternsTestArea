using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantData PlantInfo;

    private SetPlantInfo spi;

    private void Start()
    {
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.planeName.text = PlantInfo.Name;
        spi.phreatLevel.text = PlantInfo.Threath.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = PlantInfo.Icon;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && PlantInfo.Threath == PlantData.THREATH.High)
        {
            PlayerControl.dead = true;
        }
    }
}

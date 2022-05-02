using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvıs : MonoBehaviour
{
    //It must be on an obnject that has a renderer
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}

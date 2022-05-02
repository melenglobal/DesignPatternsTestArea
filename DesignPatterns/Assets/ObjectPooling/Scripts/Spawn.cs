using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject astreoid;

    // Update is called once per frame
    void Update()
    {
        SetAsteroid();
    }
    

    private void SetAsteroid()
    {
        if (Random.Range(0,100) < 4)
        {
            GameObject ast = Pool.singleton.Get("Asteroid");

            if (ast != null)
            {
                ast.SetActive(true);
                ast.transform.position = this.transform.position + new Vector3(Random.Range(-10, 11), 0, 0);
                ast.transform.rotation = Quaternion.identity;
            }
        }
    }
}

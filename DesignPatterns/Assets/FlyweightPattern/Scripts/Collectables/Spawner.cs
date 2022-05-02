using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    
    public GameObject eggPrefab;

    public GameObject medkitPrefab;
    
    public Terrain m_Terrain;

    private TerrainData _TerrainData;

    //public Event eggDrop;
    
    
    void Start()
    {
        _TerrainData = m_Terrain.terrainData;
        InvokeRepeating("CreateEgg",1,1f);
        
        InvokeRepeating("CreateMedkit",1,0.1f);
    }

    void CreateEgg()
    {
        int x = (int)Random.Range(0, _TerrainData.size.x);
        
        int z = (int)Random.Range(0, _TerrainData.size.z);

        Vector3 pos = new Vector3(x, 0, z);

        pos.y = m_Terrain.SampleHeight(pos) + 10;

        GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);

       // eggDrop.Occured(egg);
    }
    
    void CreateMedkit()
    {
        int x = (int)Random.Range(0, _TerrainData.size.x);
        
        int z = (int)Random.Range(0, _TerrainData.size.z);

        Vector3 pos = new Vector3(x, 0, z);

        pos.y = m_Terrain.SampleHeight(pos) + 10;

        GameObject medkit = Instantiate(medkitPrefab, pos, Quaternion.identity);

        // eggDrop.Occured(egg);
    }
}

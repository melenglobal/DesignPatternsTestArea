using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "planddata",menuName = "Plant Data",order = 51)]
public class PlantData : ScriptableObject
{
   public enum THREATH { None,Low,Moderate,High }

   [SerializeField] 
   private string plantName;

   [SerializeField] 
   private THREATH plantThreath;

   [SerializeField] 
   private Texture icon;

   public string Name
   {
      get { return plantName; }
   }

   public THREATH Threath
   {
      get { return plantThreath; }
   }

   public Texture Icon
   {
      get { return icon; }
   }
}

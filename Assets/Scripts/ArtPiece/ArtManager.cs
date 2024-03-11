using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        Type_01,
        Type_02,
        Type_03
    }

    public List<ArtSetup> artSetups;


   /* public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetups.ForEach(i => i.artType = artType);
    }*/
}


[System.Serializable]
public class ArtSetup
{
   public ArtManager.ArtType artType;
   public GameObject gameObject;
}
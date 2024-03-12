using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArtPiece : MonoBehaviour
{
    public GameObject currentArt;

    public Transform artContainer;


    /*public void ChangePiece(GameObject piece)
    {

        if (currentArt != null) DestroyImmediate(currentArt);

        currentArt = Instantiate(piece, artContainer);
        currentArt.transform.localPosition = Vector3.zero;
    }*/

    public void ChangePiece(GameObject piece)
    {

        // Create a new instance of the prefab
        GameObject newArt = Instantiate(piece, artContainer);

        // Destroy the previous instantiated object if it exists
        if (currentArt != null)
        {
            Destroy(currentArt);
        }

        // Set the new instance as the currentArt
        currentArt = newArt;
        currentArt.transform.localPosition = Vector3.zero;
    }

}

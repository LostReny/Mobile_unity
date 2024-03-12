using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject currentArt;


    public void ChangePiece(GameObject piece)
    {

        if (currentArt != null) DestroyImmediate(currentArt);

        currentArt = Instantiate(piece, transform.position, transform.rotation, transform.parent);
        currentArt.transform.localPosition = Vector3.zero;
    }
}

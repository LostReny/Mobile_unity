using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChangeController : MonoBehaviour
{
   public float duration;
   public MeshRenderer meshRenderer;

   public Color startColor = Color.white; 

   public Color _correctColor;


    private void Start()
    {
        _correctColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

   private void LerpColor()
   {
        meshRenderer.materials[0].SetColor("_Color",startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration);
   }


}

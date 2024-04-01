using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
   [Header("Animation")]
   public float scaleDuration;
   public float scaleBounce; 
   public Ease ease = Ease.OutBack;


   private void Update()
   {
        Bounce();
   }

   public void Bounce()
   {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
   }
}

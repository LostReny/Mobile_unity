using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleController : MonoBehaviour
{
    public PlayerController _playerController;
    public float duration = 1f;

    [Header("Scale")]
    public Vector3 startSmall = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 normalSize = new Vector3(1f, 1f, 1f);

    [Header("Ease")]
    public Ease ease = Ease.OutBack;

    [Header("Animation")]
   public float scaleDuration;
   public float scaleBounce;


    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        _playerController.transform.localScale = startSmall;
        yield return null;


        _playerController.transform.DOScale(normalSize, duration).SetEase(ease);
        yield return null;
     
    }

    private void Update()
   {
        if(Input.GetKeyDown(KeyCode.M)){
            Bounce();
        }
   }

   public void Bounce()
   {
        _playerController.transform.localScale = normalSize; 
        _playerController.transform.DOScale(scaleBounce, scaleDuration).SetEase(Ease.InOutBack).SetLoops(2, LoopType.Yoyo);
   }
}

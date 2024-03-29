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


    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        _playerController.transform.localScale = startSmall;
        yield return null;


        _playerController.transform.DOScale(normalSize, duration).SetEase(ease);
        yield break;
     
    }
}

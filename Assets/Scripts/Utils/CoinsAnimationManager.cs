using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using DG.Tweening;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    // toda vez que uma moeda for usada - vai ser instanciada aqui 
    // pq estamos usando um songleton
    // singleton - design pattern - vai acessado várias vezes no projeto

    public List<ItemCollectBase> itens;

    public float scaleDuration;
    public float scaleTimeBetweenPieces;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollectBase>();
    }

    public void RegisterCoin(ItemCollectBase i)
    {
        if(!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }

    }


    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime()); 
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach(var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        Sort();
        yield return null;

        for(int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }


    private void Sort()
    {
        itens = itens.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();
    }

    public void UnRegisterCoin(ItemCollectBase p)
    {
        if (itens.Contains(p))
        {
            itens.Remove(p);
        }
    }
}

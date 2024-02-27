using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectCoin : ItemCollectBase
{
    public Collider _collider;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;



    protected override void OnCollect()
    {
        base.OnCollect();
        ItemCollectManager.Instance.AddCoins();
        _collider.enabled = false;
    }
    
}

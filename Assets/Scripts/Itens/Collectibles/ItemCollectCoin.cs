using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectCoin : ItemCollectBase
{
    public Collider _collider; 

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemCollectManager.Instance.AddCoins();
        _collider.enabled = false;
    }
    
}

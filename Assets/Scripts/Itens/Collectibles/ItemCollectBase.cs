using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectBase : MonoBehaviour
{
    public string compareTag = "Player";

    public float timeToHide = 1;
    public GameObject graphicItem;

    public void OnTriggerEnter(Collider collision) {

        if(collision.transform.CompareTag(compareTag)){
            Collect();
        }
        
    }

    protected virtual void Collect(){

        OnCollect();

        if (graphicItem != null) graphicItem.SetActive(true);
        Invoke("HideObject", timeToHide);
        Destroy(gameObject, 10f);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
        
    }


    protected virtual void OnCollect()
    {

    }

}

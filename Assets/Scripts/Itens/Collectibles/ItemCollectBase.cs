using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectBase : MonoBehaviour
{
    public string compareTag = "Player";

    //public string _compareTagCoin = "CoinCollector";

    public float timeToHide = 1;
    public GameObject graphicItem;

    //[Header("Particle system")]
    //public VFXManager vFXManager;
    public ParticleSystem _particleSystem;

    public void OnTriggerEnter(Collider collision) {

        if(collision.transform.CompareTag(compareTag)){
            Collect();
        }
        
    }


    public void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);
    }

    protected virtual void Collect(){

        OnCollect();

        // particle system não está funcionando
        // qual o problema ?
        // necessário colocar ela em outro lugar ?
        
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        CoinsAnimationManager.Instance.BounceEffect();
        Destroy(gameObject, 10f);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
        
    }


    protected virtual void OnCollect()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.COIN, transform.position);
    }

    private void OnDestroy()
    {
        CoinsAnimationManager.Instance.UnRegisterCoin(this);
    }
}

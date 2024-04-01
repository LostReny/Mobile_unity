using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    //public
    public float speed = 1f;
    [Header("Tag")]
    public string EnemyTag = "Enemy";
    public string EndLine = "EndLine";

    //private
    [Header("EndGame")]
    public bool _canRun;

    public GameObject endScreen;

    [Header("PowerUp")]
    public float _currentSpeed;
    public Vector3 _startPosition;
    public bool invincible = false;
    public TextMeshProUGUI uiTextPowerup;
    
    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;
    private float _baseSpeedAnim = 4;

    [Header("Bounce")]
    [SerializeField] private ScaleController _scaleController;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }


    public void BounceEffect()
    {   
        if(_scaleController !=null)
            _scaleController.Bounce();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == EnemyTag) 
        {
            if (!invincible)
            {
                MoveBack(collision.transform);
                EndGame(AnimatorManager.AnimatorType.DEAD);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == EndLine)
        {
            if(!invincible) EndGame();
        }
    }
    public void SetInvencible(bool b)
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount,
        animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);

    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimatorType animationType = AnimatorManager.AnimatorType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimatorType.RUN, _currentSpeed/_baseSpeedAnim);
    }

    public void SetPowerUpText(string s)
    {
        uiTextPowerup.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

}

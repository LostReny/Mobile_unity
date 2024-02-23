using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

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

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == EnemyTag) 
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == EndLine)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    public void SetPowerUpText(string s)
    {
       //uiTextPowerUp.text = s;
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

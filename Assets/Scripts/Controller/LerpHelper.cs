using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("FollowPlayer")]
    public float speed_p = 1f;

    private Vector3 _pos;

    public GameObject _gameObject;

    public string EnemyTag = "Enemy";
    public string EndLine = "EndLine";

    public bool _isMoving;


    private void Start()
    {
        
    }

    void Update()
    {
        if (!_isMoving) return;
        PositionPlayer();

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed_p * Time.deltaTime);
    }

    void PositionPlayer()
    {
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;
    }

   public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == EnemyTag)
        {
            _isMoving = false; 
            Destroy(_gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == EndLine)
        {
            _isMoving = false;
            Destroy(_gameObject);
        }
    }

    public void StartMoving()
    {
        _isMoving = true;
    }
}
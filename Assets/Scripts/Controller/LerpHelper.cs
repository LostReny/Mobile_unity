using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LerpHelper : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("FollowPlayer")]
    public float speed_p = 1f;

    private Vector3 _pos;

    //public bool _canRunLerp;

    //public string EnemyTag = "Enemy";


    private void Start()
    {
        //_canRunLerp = true;
    }

    void Update()
    {
        //if (!_canRunLerp) return;
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

  /*  public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == EnemyTag)
        {
            _canRunLerp = false;
        }
    }*/
}

// sem um rigdbody para parar 
// como posso fazer ele seguir o player e parar quando ele parar ?
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public
    public float speed = 1f;
    [Header("Tag")]
    public string EnemyTag = "Enemy";

    //private
    [Header("EndGame")]
    public bool _canRun;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == EnemyTag) 
        {
            _canRun = false;
        }
    }

    public void StartToRun()
    {
        _canRun = true;
    }
}

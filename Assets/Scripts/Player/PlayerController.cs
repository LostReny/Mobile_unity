using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
}

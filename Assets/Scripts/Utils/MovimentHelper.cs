using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1f;



    public void Start()
    {
        StartCoroutine(startMoviment());
    }


    IEnumerator startMoviment()
    {
        float time = 0;

        while(true)
        {
            var currentPosition = transform.position;

            while(time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[0].transform.position,(time/duration));

                time += Time.deltaTime;
                yield return null;
            }

            yield return null;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPos;
    public float velocity = 1f;

    void Update()
    {
        // pega um toque na tela 
        if (Input.GetMouseButton(0))
        {
            // pos atual - pos passada
            Move(Input.mousePosition.x - pastPos.x);

        }
        pastPos = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}

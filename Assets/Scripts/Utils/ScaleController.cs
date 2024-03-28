using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleController : MonoBehaviour
{
    public PlayerController _playerController;

    IEnumerator Scale()
    {
        _playerController.transform.localScale = Vector3.zero;
       // var _currentScale = _playerController.transform.localScale;
       // n�o pode ser vector 3 
       // como transformar em int?

        yield return null;


       /* for(int i = 0; i < _currentScale; i++)
        {
            _playerController.transform.DOScale(1, .2f);
            yield return new WaitForSeconds(.1f);
        }*/
    }
}

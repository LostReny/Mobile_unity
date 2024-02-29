using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator; 
    public List<AnimatorSetup> animatorSetup;

  public enum AnimatorType
    {
        RUN,
        IDLE,
        DEAD
    }

    public void Play(AnimatorType type)
    {
        foreach(var animation in animatorSetup)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }

    public void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            Play(AnimatorType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.S))
           {
            Play(AnimatorType.IDLE);
           }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Play(AnimatorType.DEAD);   
        }*/
    }

}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimatorType type;
    public string trigger;
}
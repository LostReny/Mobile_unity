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

    public void Play(AnimatorType type, float _currentSpeedFactor = 1)
    {
        foreach(var animation in animatorSetup)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * _currentSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
       
    }

}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimatorType type;
    public string trigger;
    public float speed = 1f;
}
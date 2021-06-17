using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitBase : TeamObject, IPunObservable, IAnimationStateController
{
    protected AnimationState currentAnimationState;


    protected Animator animator;

    public UnitBase TargetEnemy { get; protected set; }

  

    // Start is called before the first frame update
    void Start()
    {
        IniTeamObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterOnTriggerAnimationState(AnimationState type)
    {
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            animator.SetBool(animator.runtimeAnimatorController.animationClips[i].name, false);
        }

        animator.SetTrigger(type.ToString());
    }

    public void SetAnimationState(AnimationState type)
    {
        if (type != currentAnimationState)
        {
            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                animator.SetBool(animator.runtimeAnimatorController.animationClips[i].name, false);
            }
            animator.SetBool(type.ToString(), true);
            currentAnimationState = type;
        }
    }
}

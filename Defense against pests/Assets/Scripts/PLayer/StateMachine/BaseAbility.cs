using UnityEngine;

public class BaseAbility : MonoBehaviour
{
    protected Player player;
    protected StateMachine linkedStateMachine;
    protected Animator linkedAnimator;
    protected PhysicsControl linkedPhysicsControl;

    public PlayerStates.State thisAbilityState;
    public bool isPermitted = true;

    protected virtual void Start()
    {
        Initialization();
    }

    public virtual void EnterAbility() { }

    public virtual void ExitAbility() { }

    public virtual void ProcessAbility() { }

    public virtual void ProcessFixedAbility() { }

    public virtual void UpdateAnimator() { }

    public virtual void Initialization()
    {
        player = GetComponent<Player>();
        if (player != null)
        {
            linkedStateMachine = player.stateMachine;
            linkedPhysicsControl = player.physicsControl;
        }
    }
}

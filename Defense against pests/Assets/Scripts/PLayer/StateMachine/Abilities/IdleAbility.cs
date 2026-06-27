using UnityEngine;

public class IdleAbility : BaseAbility
{
    private string idleAnimParameterName = "Idle";
    private int idleParameterInt;

    public override void Initialization()
    {
        base.Initialization();
        idleParameterInt = Animator.StringToHash(idleAnimParameterName);
    }

    public override void EnterAbility()
    {
        base.EnterAbility();
        linkedPhysicsControl.rb.linearVelocity = new Vector3(0, 0, 0);
    }

    public override void ProcessAbility()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            linkedStateMachine.ChangeState(PlayerStates.State.Walk);
        }
    }
}

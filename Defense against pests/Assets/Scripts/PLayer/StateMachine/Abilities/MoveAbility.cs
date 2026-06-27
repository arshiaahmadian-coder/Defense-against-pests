using UnityEngine;

public class MoveAbility : BaseAbility
{
    [SerializeField] private float speed;
    private string runAnimParameterName = "Run";
    private int runParameterInt;

    public override void Initialization()
    {
        base.Initialization();
        runParameterInt = Animator.StringToHash(runAnimParameterName);
    }

    public override void ProcessAbility()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            linkedStateMachine.ChangeState(PlayerStates.State.Idle);
        }
    }

    public override void ProcessFixedAbility()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, z);
        if (move.sqrMagnitude > 1f) move = move.normalized;

        linkedPhysicsControl.rb.linearVelocity = new Vector3(move.x * speed,
            linkedPhysicsControl.rb.linearVelocity.y, move.y * speed);
    }
}

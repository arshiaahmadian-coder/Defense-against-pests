using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine stateMachine;
    public PhysicsControl physicsControl;
    public BaseTile selectedTile;
    public PlayerInventory Inventory;
    public Interact Interact;
    public PlayerExp PlayerExp;

    private BaseAbility[] playerAbilities;

    public static Player instance;
    private void Awake()
    {
        stateMachine = new StateMachine();
        Inventory = GetComponent<PlayerInventory>();
        Interact = GetComponent<Interact>();
        playerAbilities = GetComponents<BaseAbility>();
        stateMachine.arrayOfAbilities = playerAbilities;
        instance = this;
    }

    private void Start()
    {
        physicsControl = GetComponent<PhysicsControl>();
    }

    private void Update()
    {
        foreach (BaseAbility ability in playerAbilities)
        {
            if (ability.thisAbilityState == stateMachine.currentState)
            {
                ability.ProcessAbility();
            }
            ability.UpdateAnimator();
        }
    }

    private void FixedUpdate()
    {
        foreach (BaseAbility ability in playerAbilities)
        {
            if (ability.thisAbilityState == stateMachine.currentState)
            {
                ability.ProcessFixedAbility();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringAbility : BaseAbility
{
    private float _timer;
    [SerializeField] private float wateringTime;
    
    public override void Initialization()
    {
        base.Initialization();
    }

    public override void ExitAbility()
    {
        base.ExitAbility();
        _timer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            TryToWetTile();
        }
    }

    private void TryToWetTile()
    {
        if (!isPermitted) return;
        if (player.selectedTile.isPlowed)
        {
            WetTile();
        }
    }

    public void WetTile()
    {
        _timer = wateringTime;
        linkedStateMachine.ChangeState(PlayerStates.State.Watering);
    }

    public override void ProcessAbility()
    {
        _timer -= Time.deltaTime;
        
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            linkedStateMachine.ChangeState(PlayerStates.State.Walk);

        if (_timer <= 0 && linkedStateMachine.currentState == PlayerStates.State.Watering) // planting time finished
        {
            player.selectedTile.GetWet();
            linkedStateMachine.ChangeState(PlayerStates.State.Idle);
        }
    }
}

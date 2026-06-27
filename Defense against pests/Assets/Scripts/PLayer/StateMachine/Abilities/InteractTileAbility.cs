using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTileAbility : BaseAbility
{
    private float _interactingTime;
    private float _timer;
    public override void Initialization()
    {
        base.Initialization();
    }

    public override void EnterAbility()
    {
        _interactingTime = player.selectedTile.interactingTime;
        _timer = _interactingTime;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            TryToInteract();
        }
    }

    private void TryToInteract()
    {
        if (isPermitted == false && player.selectedTile == null) return;
        // if the selected ground can be plowed -> call "Plow" function
        Interact();
    }
    
    private void Interact()
    {
        linkedStateMachine.ChangeState(PlayerStates.State.InteractWithTile);
    }

    public override void ProcessAbility()
    {
        _timer -= Time.deltaTime;
        
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && _interactingTime - _timer > 0.2f)
            linkedStateMachine.ChangeState(PlayerStates.State.Walk);

        if (_timer <= 0)
        {
            player.selectedTile.Interact();
            linkedStateMachine.ChangeState(PlayerStates.State.Idle);
        }
    }
}
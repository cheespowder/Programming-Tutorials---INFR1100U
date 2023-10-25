using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    public static GameControls _GameControls;
    
    public static void init(Player myPlayer)
    {
        _GameControls = new GameControls();
        
        _GameControls.Permanent.Enable();
        
        _GameControls.InGame.Movement.performed += jude =>
        {
            myPlayer.SetMovementDirection(jude.ReadValue<Vector3>());
        };


        _GameControls.InGame.Jump.performed += jobe =>
        {
           myPlayer.Jump();
        };

        _GameControls.InGame.Shoot.performed += gio =>
        {
            Debug.Log("shooting");
        };
    }


    public static void SetGameControls()
    {
        _GameControls.InGame.Enable();
        _GameControls.UI.Disable();
    }

    public static void SetUIControls()
    {
        _GameControls.UI.Enable();
        _GameControls.InGame.Disable();
    }





}

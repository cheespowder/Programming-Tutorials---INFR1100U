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
            myPlayer.Shoot();
        };

        _GameControls.InGame.Look.performed += vini =>
        {
            myPlayer.SetLookRotation(vini.ReadValue<Vector2>());
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

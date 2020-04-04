using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    
    private InputMaster inputMaster;
    public int i;

    void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Cube.Place.performed += _ => LeftClick();
        inputMaster.Cube.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }
    

    void LeftClick()
    {
        Debug.Log("Clicked");
    }

    void Move(Vector2 v2)
    {
        Debug.Log("Move: " + v2);
    }

    private void OnDisable()
    {
        inputMaster.Cube.Disable();
    }

    private void OnEnable()
    {
        inputMaster.Cube.Enable();
    }


}

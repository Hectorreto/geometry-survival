using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmbededSyntax : MonoBehaviour
{
    public InputAction ShootAction;

    private void OnEnable()
    {
        ShootAction.performed += Shoot;
        ShootAction.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot(InputAction.CallbackContext value)
    {
        print("Shoot assigned");    
    }

    private void OnDisable()
    {
        ShootAction.performed -= Shoot;
        ShootAction.Disable();
    }

}

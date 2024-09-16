using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class EmbededSyntax : MonoBehaviour
{
    public InputAction shootAction;
    public InputAction shootGamepad;
    public InputAction dashAction;
    public InputAction moveAction;
    public InputAction mouseRotationAction;
    public InputAction gamepadRotationAction;

    private PowerUpManager powerUpManager;

    [SerializeField] public float speed;
    private Rigidbody2D rb;
    private Vector2 direction, directionGamepad, rotationGamepad;
    private Vector3 aimPosition;
    private float zRotation;

    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int speedProjectile;

    [SerializeField] private float shootCooldown;
    private float lastShootTime;

    public FloatingJoystick leftFloatingJoystick;
    public FloatingJoystick rightFloatingJoystick;

    // public AudioClip shootSoundClip;
    // private AudioSource shootAudioSource;

    private void OnEnable()
    {
        shootAction.performed += Shoot;
        //shootAction.canceled += Shoot;
        shootAction.Enable();

        dashAction.performed += Dash;
        dashAction.Enable();

        shootGamepad.Enable();
        //shootGamepad.performed += GamepadShoot;

        moveAction.performed += Move;
        moveAction.canceled += StopMove;
        moveAction.Enable();

        mouseRotationAction.performed += MouseRotation;
        mouseRotationAction.Enable();

        //gamepadRotationAction.performed += GamepadRotation;
        gamepadRotationAction.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpManager = GetComponent<PowerUpManager>();
        // shootAudioSource = GetComponent<AudioSource>();
        // shootAudioSource.clip = shootSoundClip;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 normalJoystickDirection = gamepadRotationAction.ReadValue<Vector2>();
        Vector2 touchJoystickDirection = rightFloatingJoystick.Direction;
        Vector2 direction = normalJoystickDirection;
        if (touchJoystickDirection.magnitude > normalJoystickDirection.magnitude)
        {
            direction = touchJoystickDirection;
        }

        if (direction.magnitude > 0.1f)
        {
            GamepadRotation(direction.normalized);
        }
    }

    private void FixedUpdate()
    {
        Vector2 normalJoystickDirection = this.direction;
        Vector2 touchJoystickDirection = leftFloatingJoystick.Direction;
        Vector2 direction = normalJoystickDirection;
        if (touchJoystickDirection.magnitude > normalJoystickDirection.magnitude)
        {
            direction = touchJoystickDirection;
        }

        rb.velocity = new Vector2 (direction.x, direction.y) * speed;
    }

    private void Shoot(InputAction.CallbackContext value)
    {
        Vector3 shootDirection = aimPosition - shootPosition.position;
        GameObject tempProjectile = Instantiate(projectilePrefab, shootPosition.position, transform.rotation);
        tempProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * speedProjectile;
        // shootAudioSource.Play();
    }

    private void Dash(InputAction.CallbackContext value)
    {
        powerUpManager.ActivateDash();
    }

    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void MouseRotation(InputAction.CallbackContext value)
    {
        Vector2 mousePosition = value.ReadValue<Vector2>();
        aimPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0));
        Vector3 direction = aimPosition - transform.position;
        ApplyRotation(direction);
    }

    private void GamepadRotation(/*InputAction.CallbackContext*/ Vector2 value)
    {
        //print("Holiwi");    
        Vector2 directionStick = value;
        if(directionStick != Vector2.zero)
        {
            ApplyRotation(directionStick);
            if (Time.time-lastShootTime > shootCooldown)
            {
                GameObject tempProjectile = Instantiate(projectilePrefab, shootPosition.position, transform.rotation);
                tempProjectile.GetComponent<Rigidbody2D>().velocity = directionStick.normalized * speedProjectile;
                Destroy(tempProjectile,2.0f);
                // shootAudioSource.Play();
                lastShootTime = Time.time;
            }

        }
    }

    private void ApplyRotation(Vector2 rotationDir)
    {
        zRotation = Mathf.Atan2(rotationDir.y, rotationDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }

    private void OnDisable()
    {
        shootAction.performed -= Shoot;
        //shootAction.canceled -= Shoot;
        shootAction.Disable();

        dashAction.performed -= Shoot;
        dashAction.Disable();

        //shootGamepad.performed -= GamepadShoot;
        shootGamepad.Disable();

        moveAction.performed -= Move;
        moveAction.canceled -= StopMove;
        moveAction.Disable();

        mouseRotationAction.performed -= MouseRotation;
        mouseRotationAction.Disable();

        //gamepadRotationAction.performed -= GamepadRotation;
        gamepadRotationAction.Disable();
    }

}

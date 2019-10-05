using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private MovementSettings movementSettings = null;
    [SerializeField]
    private IInputManager inputManager = null;
    [SerializeField]
    private Animator animator = null;

    private Vector2 movement;

    public void Awake()
    {
        inputManager = movementSettings.BuildInputManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

    private void FixedUpdate()
    {
        updatePlayerPosition();
    }

    private void handleInput()
    {
        movement = inputManager.GetDirection();
        /*
        animator.SetFloat(HORIZONTAL, movement.x);
        animator.SetFloat(VERTICAL, movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude * movementSettings.GetSpeed());
        */
    }

    private void updatePlayerPosition()
    {
        rb.MovePosition(rb.position + movement * movementSettings.GetSpeed() * Time.fixedDeltaTime);
    }
}

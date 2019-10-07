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

    [SerializeField]
    private GameObject target = null;
    [SerializeField]
    private float allowedDistance;

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

    public void OverrideInputManager(IInputManager inputManager)
    {
        this.inputManager = inputManager; 
    }

    private void handleInput()
    {
        Vector3 v = inputManager.GetDirection();
        if(null != target && movementSettings.GetIsAi())
        {
            if ((target.transform.position - this.transform.position).magnitude < allowedDistance /*&& Vector3.Dot(target.transform.position - this.transform.position, v) > 0*/)
            {
                //Debug.Log("using idle direction");
                movement = v;
            } else
            {
                movement = (target.transform.position - this.transform.position).normalized;
            }
        } else
        {
            movement = v;
        }
        
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

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void SetAllowedDistance(float allowedDistance)
    {
        this.allowedDistance = allowedDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Follower") || collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), collision.collider);
        }
    }
}

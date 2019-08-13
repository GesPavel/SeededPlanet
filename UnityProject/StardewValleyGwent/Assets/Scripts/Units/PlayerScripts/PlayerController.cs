using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode left, right, up, down;
    public float speed;
    public float moveDelay;
    public GameObject leftHand, rightHand;
    private Ground currentGroundPosition;
    private Rigidbody2D rb2d;
    private StaminaDirector stamina;
    private HandController handController;
    HandController hand;
    Bed bed;
    [SerializeField] private LayerMask blockingLayer;
    [SerializeField] private LayerMask lakeLayer;
    private Vector3 lookDirection;
    private Vector3 destinationPoint;
    private bool moving;
    private bool isplayerTurned = false;

    private const float DELAY_BEFORE_PLAYER_CAN_MOVE=0.15f;
    private float delayBeforeMove = 0;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        stamina = GetComponent<StaminaDirector>();
        moving = false;
        DontDestroyOnLoad(this.gameObject);
        hand = GetComponentInChildren<HandController>();
        bed = FindObjectOfType<Bed>();
        destinationPoint = transform.position;
        handController = GetComponentInChildren<HandController>();

    }
    void Update()
    {
        if (stamina.CurrentStamina <= 0)
        {
            moving = false;
            stamina.Faint();
        }
    }
    private void FixedUpdate()
    {
        MoveControll();
    }

    private void MoveControll()
    {
        lookDirection = GetLookDirectionMobile();
        if (transform.up != lookDirection && lookDirection!=Vector3.zero &&!moving)
        {
            transform.up = lookDirection;
            delayBeforeMove = DELAY_BEFORE_PLAYER_CAN_MOVE;
            return;
        }
        if (delayBeforeMove > 0)
        {
            delayBeforeMove -= Time.fixedDeltaTime;
            return;
        }
        if (!moving && lookDirection!=Vector3.zero)
        {
            if (transform.up != lookDirection)
            {
                transform.up = lookDirection;
                return;
            }
            transform.up = lookDirection;
            if (CanMove(lookDirection))
            {
                destinationPoint = transform.position + lookDirection;
                moving = true;
            }
        }
        else if (moving)
        {
            float remainingDistance = (transform.position - destinationPoint).magnitude;
            if (remainingDistance < speed * Time.fixedDeltaTime)
            {
                AttemtContinueMovement();
            }
            MakeStepToDestination(destinationPoint);
        }
    }
    private void AttemtContinueMovement()
    {
        lookDirection = GetLookDirectionMobile();
        if (transform.up == lookDirection)
        {
            if (CanMove(lookDirection))
            {
                destinationPoint += lookDirection;
            }
        }
        else
        {
            transform.position = destinationPoint;
            moving = false;
            return;
        }
    }
    private void MakeStepToDestination(Vector3 destinationPoint)
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.fixedDeltaTime);
        rb2d.MovePosition(newPos);
    }
   
    private Vector3 GetLookDirectionMobile()
    {
        Vector3 lookDirecttion = Vector3.zero;
        lookDirection.x = Input.GetAxis("Horizontal");
        lookDirection.y = Input.GetAxis("Vertical");
        return lookDirection;
    }
    private bool CanMove(Vector3 direction)
    {
        RaycastHit2D blockingHit = Physics2D.Raycast(rb2d.transform.position, direction, 1.1f, blockingLayer);
        RaycastHit2D lakeHit = Physics2D.Raycast(rb2d.transform.position, direction, 1.1f, lakeLayer);
        if (lakeHit.collider || blockingHit.collider != null) return false;
        return true;
    }

    public Ground GetCurrentGroundPosition()
    {
        return currentGroundPosition;
    }

    public void SetCurrentGroundPosition(Ground ground)
    {

        currentGroundPosition = ground;
    }
    public void MoveToBed()
    {
        transform.position = bed.GetWakeUpPoint().transform.position;
    }
}

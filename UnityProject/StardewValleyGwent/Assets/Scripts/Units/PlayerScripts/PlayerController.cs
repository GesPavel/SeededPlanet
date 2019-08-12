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

#if UNITY_STANDALONE
        lookDirection = GetLookDirection;
#elif UNITY_ANDROID
        lookDirection = GetLookDirectionMobile();
#endif
        if (transform.up != lookDirection && lookDirection != Vector3.zero)
        {
            transform.up = lookDirection;
            isplayerTurned = true;
            return;
        }
        if (lookDirection == Vector3.zero)
        {
            isplayerTurned = false;
        }
        if (!moving && !isplayerTurned)
        {
            if (lookDirection == Vector3.zero)
            {
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
    private void MakeStepToDestination(Vector3 destinationPoint)
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.fixedDeltaTime);
        rb2d.MovePosition(newPos);
    }
    private void AttemtContinueMovement()
    {
#if UNITY_STANDALONE
        lookDirection = GetLookDirection;
#elif UNITY_ANDROID
        lookDirection = GetLookDirectionMobile();
#endif
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
    private Vector3 GetLookDirection()
    {
        Vector3 lookDir = Vector3.zero;
        if (Input.GetKey(left))
        {
            lookDir = Vector3.left;
        }
        else if (Input.GetKey(right))
        {
            lookDir = Vector3.right;
        }
        else if (Input.GetKey(up))
        {
            lookDir = Vector3.up;
        }
        else if (Input.GetKey(down))
        {
            lookDir = Vector3.down;
        }
        return lookDir;
    }
    private Vector3 GetLookDirectionMobile()
    {
        Vector3 lookDirecttion = Vector3.zero;
        lookDirection.x = Input.GetAxis("Horizontal");
        lookDirection.y = Input.GetAxis("Vertical");
        Debug.Log(lookDirection);
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

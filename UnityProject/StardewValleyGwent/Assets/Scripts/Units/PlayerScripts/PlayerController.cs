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
    private Inventory inventory;
    HandController hand;
    Bed bed;
    [SerializeField] private LayerMask blockingLayer;
    [SerializeField] private LayerMask lakeLayer;
    private Vector3 lookDirection;
    private Vector3 destinationPoint;
    private bool moving;

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
        inventory = GetComponent<Inventory>();
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
        if (!moving)
        {
            lookDirection = GetLookDirection();
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
            MakeStepToDestination(ref destinationPoint);
        }
    }
    private void MakeStepToDestination(ref Vector3 destinationPoint)
    {
        float remainingDistance = (transform.position - destinationPoint).magnitude;
        if (remainingDistance < float.Epsilon)
        {
            transform.position = destinationPoint;
            moving = false;
            return;
        }
        Vector3 newPos = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.fixedDeltaTime);
        rb2d.MovePosition(newPos);
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
    private bool CanMove(Vector3 direction)
    {
        RaycastHit2D blockingHit = Physics2D.Raycast(rb2d.transform.position, direction, 1, blockingLayer);
        RaycastHit2D lakeHit = Physics2D.Raycast(rb2d.transform.position, direction, 1, lakeLayer);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(handController.takeItemfFromGround))
        {
            if (collision.gameObject.GetComponent<IItem>() != null)
            {
                if (collision.gameObject == handController.Item)
                {
                    return;
                }
                if (inventory.TrySetItem(collision.gameObject))
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        if (handController.Item == null && Input.GetKeyDown(handController.useButton))
        {
            if (collision.gameObject.GetComponent<ProductZone>() != null)
            {             
                collision.gameObject.GetComponent<ProductZone>().SpawnProduct();
            }           
        }
    }
}

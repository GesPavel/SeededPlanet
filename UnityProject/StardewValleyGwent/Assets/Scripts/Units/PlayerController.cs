using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode left, right, up, down, interact;
    public float speed;
    public float moveDelay;
    public GameObject leftHand, rightHand;

    private Ground currentGroundPosition;
    private Rigidbody2D rb2d;
    private Vector3 lookDirection;
    private Vector3 moveDirection;
    private bool moving;
    private StaminaDirector stamina;
    HandController hand;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        stamina = GetComponent<StaminaDirector>();
        moving = false;
        DontDestroyOnLoad(this.gameObject);
        hand = GetComponentInChildren<HandController>();

    }


    void Update()
    {
        if (!moving)
        {
            if (stamina.CurrentStamina <= 0)
            {
                gameObject.transform.position = FindObjectOfType<Bed>().gameObject.transform.position;
                stamina.RestoreStamina();
                return;
            }
            MoveControll();
        }
    }

    private void MoveControll()
    {
        if (Input.GetKey(left))
        {
            lookDirection = Vector3.left;
            moveDirection = lookDirection;
        }
        else if (Input.GetKey(right))
        {
            lookDirection = Vector3.right;
            moveDirection = lookDirection;
        }
        else if (Input.GetKey(up))
        {
            lookDirection = Vector3.up;
            moveDirection = lookDirection;
        }
        else if (Input.GetKey(down))
        {
            lookDirection = Vector3.down;
            moveDirection = lookDirection;
        }
        rb2d.transform.up = lookDirection;
        if (CanMove(moveDirection))
        {
            StartCoroutine(movePlayer(moveDirection + transform.position));
            moveDirection = Vector3.zero;
        }

    }

    //Функция будет проверят потенциальное столкновение игрока, если он пойдет по данному направлению.
    //Если есть препятствие, функция возвращает false.
    private bool CanMove(Vector3 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb2d.transform.position, direction, 1, LayerMask.GetMask("BlockingLayer"));
        if (hit.collider != null) return false;
        return true;
    }

    //Сопрограмма для перемещения игрока между ячейками.
    IEnumerator movePlayer(Vector3 destination)
    {
        moving = true;
        float step = speed * Time.deltaTime;
        float Remainingdistance = (transform.position - destination).sqrMagnitude;
        while (Remainingdistance > float.Epsilon)
        {
            rb2d.MovePosition(Vector3.MoveTowards(rb2d.position, destination, step));
            Remainingdistance = (rb2d.transform.position - destination).sqrMagnitude;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(moveDelay);
        moving = false;
    }
    public Ground GetCurrentGroundPosition()
    {
        return currentGroundPosition;
    }

    public void SetCurrentGroundPosition(Ground ground)
    {
        if (ground == null)
        {
            ground = null;
            return;
        }
        if (ground.GetComponent<Ground>() == null)
        {
            ground = null;
            return;
        }
        currentGroundPosition = ground;
    }
    public void FallAsleep()
    {
        stamina.RestoreStamina();

    }
    public void GoToBed()
    {
        transform.position = FindObjectOfType<Bed>().transform.position;
        FallAsleep();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IItem>() != null)
        {
            if (hand.IsEmpty())
            {
                hand.PickUpItem(collision.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode left, right, up, down, use, interact;
    public float speed;
    public float moveDelay;
    public GameObject leftHand, rightHand;
    private Rigidbody2D rb2d;
    private Vector3 lookDirection;
    private Vector3 moveDirection;
    private bool moving;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moving = false;
        DontDestroyOnLoad(this.gameObject);
        
    }


    void Update()
    {
        MoveControll();
    }

    private void MoveControll()
    {
        if (!moving)
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
        if (Input.GetKeyDown(interact))
        {
            rightHand.GetComponent<HandScript>().InteractWithEnviroment();
            
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
}

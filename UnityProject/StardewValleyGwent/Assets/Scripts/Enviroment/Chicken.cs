using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed;
    float timeForWalking = 5;
    float timeForStop = -3;
    Vector2 direction = new Vector2();
    void Start()
    {
        direction.x = Random.Range(-10, 10);
        direction.y = Random.Range(-10, 10);
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.5f, 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Environment")
        {
            if (timeForStop <= 0)
            { timeForStop += Time.deltaTime; }
            if (timeForStop > 0)
            {
                speed = Random.Range(0.5f,2);
                direction.x = direction.x * (-1) * Mathf.Sin(Random.Range(2*Mathf.PI / 3, 4 * Mathf.PI / 3));
                direction.y = direction.y * (-1) * Mathf.Sin(Random.Range(2*Mathf.PI / 3, 4 * Mathf.PI / 3));
                timeForStop = Random.Range(-1, -5);
            }
        }
    }
    void Move()
    {
        if (timeForWalking > 0)
        {
            Vector3 pos = rb.position;
            direction.Normalize();
            rb.MovePosition((Vector2)rb.transform.position + direction * speed * Time.deltaTime);
            timeForWalking -= Time.deltaTime;
        }
        else
        {
            if (timeForStop <= 0) { timeForStop += Time.deltaTime; }
            if (timeForStop > 0)
            {

                direction.x = direction.x * (-1) * Mathf.Sin(Random.Range(Mathf.PI / 3, 5 * Mathf.PI / 3));
                direction.y = direction.y * (-1) * Mathf.Sin(Random.Range(Mathf.PI / 3, 5 * Mathf.PI / 3));
                timeForWalking = Random.Range(3, 8);
                timeForStop = Random.Range(-1, -5);
            }

        }

    }
    // Update is called once er frame
    void Update()
    {
        transform.up = direction;
        Move();
    }
}

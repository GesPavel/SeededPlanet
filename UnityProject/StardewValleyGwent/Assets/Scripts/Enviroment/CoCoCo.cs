using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoCoCo : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]float speed=7f;
    bool isMoving = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    IEnumerator RandomizeDirection(float time,Vector2 direction)
    {
        transform.up = direction;
        while (time>0)
        {          
            rb.MovePosition((Vector2)rb.transform.position + direction * speed * Time.deltaTime);
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        isMoving = false;
    }
    void Move()
    {
        Vector3 pos = rb.position;
        Vector2 direction = new Vector2();
        direction.x = Random.Range(-10, 10);
        direction.y = Random.Range(-10, 10);
        direction.x = Mathf.Clamp(direction.x, -8.5f, 8.5f);
        direction.y = Mathf.Clamp(direction.y, -5f, 5f);
        direction.Normalize();
        int time = Random.Range(2, 7);
        if (!isMoving)
        { 
            isMoving = true;
            StartCoroutine(RandomizeDirection(time, direction));
        }
    }
    // Update is called once er frame
    void Update()
    {
        Move();
    }
}

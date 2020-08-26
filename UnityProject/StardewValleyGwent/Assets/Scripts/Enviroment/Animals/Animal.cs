using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Animal : MonoBehaviour
{
    protected AIPath aIPath;
    protected bool hasReachedDestination = false;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float timeForWalking = 5;
    [HideInInspector]
    public float timeForStop = -3;
    [HideInInspector]
    public Vector2 direction = new Vector2();
    public float maxSpeedRange = 2;
    public float minSpeedRange = 0.5f;
    public float maxTimeForStop = -1;
    public float minTimeForStop = -5;
    public float maxTimeForWalk = 4;
    public float minTimeForWalk = 9;
    public float maxSinRange = 4 * Mathf.PI / 3;
    public float minSinRange = 2 * Mathf.PI / 3;

    void Start()
    {
        this.gameObject.transform.SetParent(GameObject.Find("Animals").transform);
        aIPath = GetComponent<AIPath>();
        aIPath.destination = transform.parent.transform.position;

        direction.x = Random.Range(-10, 10);
        direction.y = Random.Range(-10, 10);
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeedRange, maxSpeedRange);
    }
    public virtual void Update()
    {
        if (!hasReachedDestination)
        {
            CheckIfAnimalGatheringPointReached();
        }
        else
        {
            MoveRandomly();

            OnRayCollision();
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Environment")
        {

        }
    }
    public void ChangeDirection()
    {
        speed = Random.Range(minSpeedRange, maxSpeedRange);
        direction.x = direction.x * Mathf.Sin(Random.Range(minSinRange, maxSinRange));
        direction.y = direction.y * Mathf.Sin(Random.Range(minSinRange, maxSinRange));
        timeForStop = Random.Range(minTimeForStop, maxTimeForStop);
        transform.up = direction;
    }

    public void MoveRandomly()
    {

        if (timeForWalking > 0)
        {
            Vector3 pos = rb.position;
            direction.Normalize();
            timeForWalking -= Time.deltaTime*Time.timeScale;
            rb.MovePosition((Vector2)rb.transform.position + direction * speed * Time.deltaTime * Time.timeScale);


        }
        else
        {
            if (timeForStop <= 0)
            {
                timeForStop += Time.deltaTime * Time.timeScale;
            }
            if (timeForStop > 0)
            {

                ChangeDirection();
                timeForWalking = Random.Range(minTimeForWalk, maxTimeForWalk);

            }

        }
        transform.up = direction;

    }
    public void OnRayCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));
        if (hit.collider != null)
        {
            ChangeDirection();
        }
    }
    

    protected virtual void CheckIfAnimalGatheringPointReached()
    {
        if (aIPath.reachedDestination)
        {
            aIPath.canMove = false;
            aIPath.canSearch = false;
            hasReachedDestination = true;
        }
    }
}

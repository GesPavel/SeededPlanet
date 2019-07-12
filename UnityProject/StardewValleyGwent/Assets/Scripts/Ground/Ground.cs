using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    bool IsOccupied { get; set; }

    //public Sprite[] sprites = new Sprite[2];
    public Sprite unWatered;
    public Sprite watered;

    public GroundState State { get; set; }
    //float WaterDelay=2;

    void Start()
    {
        State = gameObject.AddComponent<UnPlowedState>();

    }

    void Update()
    {
       


    }
    public void ChangeOnPlowed()
    {
        //if (State is UnPlowedState)
        //{
            Debug.Log("Changed");
            State.HandleButton(this);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // FindObjectOfType<PlayerController>().currentGroundPosition = this;
    }

}

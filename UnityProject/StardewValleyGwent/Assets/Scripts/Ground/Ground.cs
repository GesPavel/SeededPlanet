using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    bool IsOccupied { get; set; }

    public Sprite[] sprites = new Sprite[2];
    bool active = false;
    internal GroundState State { get; set; }
    float WaterDelay=2;

    // Start is called before the first frame update
    void Start()
    {
        State = gameObject.AddComponent<UnPlowedState>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            State.HandleButton(this);
        }

        if (State is WateredPlowedState)
        {
            if (WaterDelay < 0)
            {

                State.HandleButton(this);
                WaterDelay = 2;
            }
            else if (WaterDelay > 0)
            {
                WaterDelay -= Time.deltaTime;
                Debug.Log(WaterDelay);
            }
        }
    }
}

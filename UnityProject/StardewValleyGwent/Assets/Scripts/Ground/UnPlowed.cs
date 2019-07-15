using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPlowed : BaseGround
{

    void Start()
    {
    }

    public override void ChangeState()
    {
        if (gameObject != null) {
            gameObject.AddComponent<UnWateredPlowed>();
            FindObjectOfType<PlayerController>().currentGroundPosition = GetComponent<UnWateredPlowed>();
        }

        Destroy(this);
         

    }


}

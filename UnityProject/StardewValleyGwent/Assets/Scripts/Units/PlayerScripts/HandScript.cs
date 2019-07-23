//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HandScript : MonoBehaviour
//{
//    private GameObject item;
//    private GameObject player;
//    public KeyCode use;
//    void Start()
//    {
//        player = (GetComponentInParent<PlayerController>() as PlayerController).gameObject;
//    }

//    void Update()
//    {
//        if (item != null)
//        {
//            item.transform.position = transform.position;
//            if (player != null) item.transform.up = player.transform.up;
//        }
//        if (Input.GetKeyDown(use))
//        {
//            if (Usable) 
//                use(ground);
//            else if (Edible)
//               eat();
           
//        }
//    }

//    public void InteractWithEnviroment()
//    {
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("BlockingLayer"));

//        if (Container)
//        {
//            ICrate crate = (ICrate)hit.collider.GetComponent(typeof(ICrate)) as ICrate;
//            item = crate.Interact(item);
            
           
//        }
//        if (Furnuture)
//        {
//            Furnuter = fur.Interact();
//        }
//        if (Factory)
//            item = Factory.Interact();
//    }

//    public void setItem(GameObject item)
//    {
//        this.item = item;
//    }
//    public GameObject SendItem()
//    {
//        return item;
//    }

//    public void RemoveItem()
//    {
//        item = null;
//    }
//    public bool IsWithItem()
//    {
//        if (item != null) return true;
//        else return false;
//    }
//}

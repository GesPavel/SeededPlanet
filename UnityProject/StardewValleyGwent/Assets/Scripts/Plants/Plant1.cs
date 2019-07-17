using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Sprite state1, state2, state3, state4;
    [SerializeField] private float state1Time,state2Time,state3Time,state4Time;
    [SerializeField] private GameObject vegetable;
    [HideInInspector] public Ground ground;


    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = state1;
        StartCoroutine(changeState(state1Time, state2));
        StartCoroutine(changeState(state1Time+state2Time, state3));
        StartCoroutine(changeState(state1Time + state2Time + state3Time, state4));
        StartCoroutine(InstantiateVegetable(state1Time + state2Time + state3Time + state4Time));
    }
    IEnumerator changeState(float time,Sprite sprite)
    {
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    IEnumerator InstantiateVegetable(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(vegetable, transform.position, Quaternion.identity)
            .GetComponent<Vegetable>().SetPieceGround(ground);
        Destroy(this.gameObject);
    }
    
    public void SetBaseGround(Ground ground)
    {
        this.ground = ground;
    }
    void Update()
    {
        
    }
    protected void ChangeStateSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant1 : MonoBehaviour
{
    [SerializeField] private Sprite state1, state2, state3, state4;
    [SerializeField] private float state1Time,state2Time,state3Time,state4Time;
    [SerializeField] private GameObject vegetable;
    [HideInInspector] public PieceData baseGround;


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
        Instantiate(vegetable, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    
    public void SetBaseGround(BaseGround ground)
    {
        baseGround = ground.gameObject.GetComponent<PieceData>();
    }
    void Update()
    {
        
    }
    protected void ChangeStateSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

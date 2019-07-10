using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrate 
{
    void TakeFrom();
    void Put(GameObject gameObject);
}

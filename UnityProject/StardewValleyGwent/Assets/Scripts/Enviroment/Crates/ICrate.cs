using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrate 
{
    void TakeOrPutItem(HandScript hand);
    void TakeFromCrate(HandScript hand);
    void Put(HandScript hand);
}

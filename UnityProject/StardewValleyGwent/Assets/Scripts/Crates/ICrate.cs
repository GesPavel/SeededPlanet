using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICrate 
{
    void TakeOrPutItem(TransferItemScript hand);
    void TakeFromCrate(TransferItemScript hand);
    void Put(TransferItemScript hand);
}

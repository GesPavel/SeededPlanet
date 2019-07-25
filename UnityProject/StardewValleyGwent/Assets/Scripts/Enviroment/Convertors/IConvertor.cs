using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConvertor : IInteractable
{
    GameObject Convert(GameObject item);
}

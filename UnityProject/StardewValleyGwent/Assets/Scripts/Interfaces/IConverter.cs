using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConverter : IInteractable
{
    GameObject Convert(GameObject item);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManufacturer : IInteractable
{
    GameObject Interact(GameObject food);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssortmentWindow : MonoBehaviour
{
    public Transform content;
    public PriceList merhantsPriceList;
    public MerchantsSlot slotTemplace;

    private void Start()
    {  
    }

    public void ShowAssortment()
    {
        foreach(Transform chield in content)
        {
            Destroy(chield.gameObject);
        }
        for (int i = 0; i < merhantsPriceList.pairs.Count; i++)
        {
            var newSlot = Instantiate(slotTemplace);
            newSlot.transform.SetParent(content);
            newSlot.GetComponent<MerchantsSlot>().Set(merhantsPriceList.pairs[i].product);
        }
    }
}

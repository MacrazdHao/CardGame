using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotsController : MonoBehaviour
{
    public string CardId = null;
    public string CardIdBuffer;
    public Card CardInfo;
    public GameObject SlotItemPrefab;
    public float SlotItemSpacing = 4;
    void Start()
    {
        if (CardId != null)
        {
            CardIdBuffer = CardId;
            if (CardInfo != null) StartCoroutine(initCardSlots());
        }
    }

    void Update()
    {
        if (CardId != CardIdBuffer)
        {
            CardIdBuffer = CardId;
            StartCoroutine(initCardSlots());
        }
    }
    public IEnumerator initCardSlots()
    {
        // 先清空
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        float lastSlotItemAnchoredPositionX = 0;
        float lastSlotItemWidth = 0;
        int slotItemIndex = 0;
        foreach (KeyValuePair<CardTypeMap.CardTypeEnum, int> kvp in CardInfo.cardSlot.CardSlotsDictionary)
        {
            GameObject slotItem = Instantiate(SlotItemPrefab, transform);
            CardSlotItemController slotItemController = slotItem.GetComponent<CardSlotItemController>();
            RectTransform slotRectTransform = slotItem.GetComponent<RectTransform>();
            bool slotItemUpdating = true;
            slotItemController.OnUpdated = (sItem) =>
            {
                float currentSlotItemWidth = sItem.SlotItemWidth;
                float currentSlotItemAnchoredPositonX = lastSlotItemAnchoredPositionX + lastSlotItemWidth / 2 + currentSlotItemWidth / 2 + (slotItemIndex > 0 ? SlotItemSpacing : 0);
                slotRectTransform.anchoredPosition = new Vector2(currentSlotItemAnchoredPositonX, slotRectTransform.anchoredPosition.y);
                lastSlotItemAnchoredPositionX = currentSlotItemAnchoredPositonX;
                lastSlotItemWidth = currentSlotItemWidth;
                slotItemUpdating = false;
            };
            slotItemController.Value = kvp.Value;
            slotItemController.SlotType = kvp.Key;
            slotItemController.UpdateToggle = true;
            while (slotItemUpdating)
            {
                Debug.Log("waiting: " + kvp.Key);
                yield return null;
            }
            slotItemIndex++;
        }
        yield return null;
    }
}

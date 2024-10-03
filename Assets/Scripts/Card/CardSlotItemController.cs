using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotItemController : MonoBehaviour
{
    private Image SlotTypeImage;
    private RectTransform SlotTypeImageRectTransform;
    private TextSizeController TextController;
    private Text SlotItemText;
    private RectTransform SlotItemRectTransform;
    private RectTransform SlotItemTextRectTransform;
    private Sprite SlotTypeSprite;
    public CardTypeMap.CardTypeEnum SlotType;
    public int Value = 999;
    public float Spacing = 2;
    public Action<CardSlotItemController> OnUpdated;
    public bool UpdateToggle = false;
    public float SlotItemWidth;

    void Start()
    {
        SlotItemRectTransform = GetComponent<RectTransform>();
        SlotTypeImage = GetComponentInChildren<Image>();
        SlotItemText = GetComponentInChildren<Text>();
        SlotItemTextRectTransform = SlotItemText.GetComponentInChildren<RectTransform>();
        SlotTypeImageRectTransform = SlotTypeImage.GetComponent<RectTransform>();
        TextController = GetComponentInChildren<TextSizeController>();
        initCardSlotItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateToggle)
        {
            initCardSlotItem();
            UpdateToggle = false;
        }
    }
    private void initCardSlotItem()
    {
        SlotTypeSprite = ResourceLoader.SpriteDictionary[CardTypeMap.CardTypeEnumToMapKey(SlotType)];
        SlotTypeImage.sprite = SlotTypeSprite;
        TextController.OnUpdated = (textController) =>
        {
            float textWidth = textController.textPreferredWidth;
            float iconWidth = SlotTypeImageRectTransform.sizeDelta.x;
            Debug.Log("字符长度参数: " + Spacing + " " + textWidth + " " + iconWidth);
            SlotItemTextRectTransform.anchoredPosition = new Vector2(Spacing + textWidth / 2 + iconWidth, SlotItemTextRectTransform.anchoredPosition.y);
            SlotItemWidth = textWidth + iconWidth + Spacing;
            SlotItemRectTransform.sizeDelta = new Vector2(SlotItemWidth, SlotItemRectTransform.sizeDelta.y);
            if (OnUpdated != null)
            {
                OnUpdated(this);
                OnUpdated = null;
            }
        };
        TextController.text = "×" + Value;
    }
}

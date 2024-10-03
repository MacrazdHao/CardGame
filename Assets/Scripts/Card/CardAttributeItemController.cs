using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardAttributeItemController : MonoBehaviour
{
    public int Value = 0;
    public int ValueBuffer = 0;
    public Text AttributeItemText;
    public CardTypeMap.AttributeEnum AttributeType;
    void Start()
    {
        AttributeItemText = GetComponentInChildren<Text>();
        initCardAttributeItem();
        ValueBuffer = Value;
    }

    void Update()
    {
        if (Value != ValueBuffer)
        {
            initCardAttributeItem();
            ValueBuffer = Value;
        }
    }
    public void initCardAttributeItem()
    {
        AttributeItemText.text = "" + Value;
    }
}

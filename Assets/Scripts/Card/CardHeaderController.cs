using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHeaderController : MonoBehaviour
{
    public string CardId = null;
    public string CardIdBuffer;
    public Card CardInfo;
    private Image CardTypeImage;
    private Text CardNameText;

    void Start()
    {
        CardTypeImage = transform.GetComponentInChildren<Image>();
        CardNameText = transform.GetComponentInChildren<Text>();
        if (CardId != null) initCardHeaderInfo();
    }

    void Update()
    {
        if (CardId != CardIdBuffer)
        {
            CardIdBuffer = CardId;
            initCardHeaderInfo();
        }
    }

    public void initCardHeaderInfo()
    {
        CardNameText.text = CardInfo.cardName;
        CardTypeImage.sprite = ResourceLoader.GetCardTypeSprite(CardInfo.cardType);
    }
}

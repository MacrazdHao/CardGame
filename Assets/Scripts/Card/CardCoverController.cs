using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCoverController : MonoBehaviour
{
    public string CardId = null;
    public string CardIdBuffer;
    public Card CardInfo;
    private Image CardCoverImage;
    private RectTransform CardCoverImageRect;
    // Start is called before the first frame update
    void Start()
    {
        CardCoverImage = transform.GetComponentInChildren<Image>();
        CardCoverImageRect = CardCoverImage.GetComponent<RectTransform>();
        if (CardId != null)
        {
            CardIdBuffer = CardId;
            initCardCover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CardId != CardIdBuffer)
        {
            CardIdBuffer = CardId;
            initCardCover();
        }
    }
    public void initCardCover()
    {
        if (CardInfo == null)
        {
            CardCoverImage.sprite = ResourceLoader.GetCardCover(CardTypeMap.CardKeyEnum.Card_Default);
            return;
        }
        CardCoverImage.sprite = ResourceLoader.GetCardCover(CardInfo.cardKey);
        CardCoverImageRect.anchoredPosition = new Vector2(CardInfo.cardCoverRect.posX, CardInfo.cardCoverRect.posY);
        CardCoverImageRect.sizeDelta = new Vector2(CardInfo.cardCoverRect.width, CardInfo.cardCoverRect.height);
        CardCoverImage.type = CardInfo.cardCoverRect.imageType;
    }
}

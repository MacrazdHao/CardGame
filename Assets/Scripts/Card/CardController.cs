using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public bool ReloadCard = false;
    public CardTypeMap.CardKeyEnum CurrentCard = CardTypeMap.CardKeyEnum.Card_MonkeysYell; // 等Card作为预设prefab存在时，该参数将在创建prefab时由外部传入
    public Card CardInfo;
    public CardHeaderController cardHeaderController;
    public CardCoverController cardCoverController;

    void Start()
    {
        initCard();
    }

    void Update()
    {
        if (ReloadCard) {
            ReloadCard = false;
            initCard();
        }
    }
    void initCard() {
        CardInfo = CardCases.GetANewCardCase(CurrentCard); // 等Card作为预设prefab存在时，该参数将在创建prefab时由外部传入

        cardHeaderController = GetComponentInChildren<CardHeaderController>();
        cardHeaderController.CardInfo = CardInfo;
        cardHeaderController.CardId = CardInfo.id;

        cardCoverController = GetComponentInChildren<CardCoverController>();
        cardCoverController.CardInfo = CardInfo;
        cardCoverController.CardId = CardInfo.id;
    }
}

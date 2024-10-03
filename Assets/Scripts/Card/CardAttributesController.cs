using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardAttributesController : MonoBehaviour
{
    public string CardId = null;
    public string CardIdBuffer;
    public Card CardInfo;
    private CardAttributeItemController CardMagicItemController;
    private CardAttributeItemController CardPhysicItemController;
    private CardAttributeItemController CardAttackItemController;
    private CardAttributeItemController CardDefenceItemController;

    void Start()
    {
        CardAttributeItemController[] cardAttributeItemControllers = GetComponentsInChildren<CardAttributeItemController>();
        for (int i = 0; i < cardAttributeItemControllers.Length; i++)
        {
            switch (cardAttributeItemControllers[i].AttributeType)
            {
                case CardTypeMap.AttributeEnum.Magic: CardMagicItemController = cardAttributeItemControllers[i]; break;
                case CardTypeMap.AttributeEnum.Physic: CardPhysicItemController = cardAttributeItemControllers[i]; break;
                case CardTypeMap.AttributeEnum.Attack: CardAttackItemController = cardAttributeItemControllers[i]; break;
                case CardTypeMap.AttributeEnum.Defence: CardDefenceItemController = cardAttributeItemControllers[i]; break;
            }
        }
        if (CardId != null)
        {
            CardIdBuffer = CardId;
            initCardDescription();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CardId != CardIdBuffer)
        {
            CardIdBuffer = CardId;
            initCardDescription();
        }
    }
    public void initCardDescription()
    {
        CardMagicItemController.Value = CardInfo.cardMagic;
        CardPhysicItemController.Value = CardInfo.cardPhysic;
        CardAttackItemController.Value = CardInfo.cardAttack;
        CardDefenceItemController.Value = CardInfo.cardDefence;
    }
}

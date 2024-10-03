using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCases
{
  public static Dictionary<string, Card> CardCaseDictionary;
  // 创建一个新的卡牌对象
  public static Card GetANewCardCase(CardTypeMap.CardKeyEnum cardKey)
  {
    if (CardCaseDictionary == null) CardCaseDictionary = new Dictionary<string, Card>();
    Card newCard = (Card)ResourceLoader.CardDictionary[CardTypeMap.CardKeyToMapKey(cardKey)].Clone();
    CardCaseDictionary.Add(newCard.id, newCard);
    return newCard;
  }
}

public class Card : ICloneable
{
  public string id;
  public CardTypeMap.CardTypeEnum cardType;
  public string cardName;
  public int cardPhysic;
  public int cardMagic;
  public CardSlots cardSlot;
  public string cardCover;
  public string cardDescription;
  public int cardAttack;
  public int cardDefence;
  public int cardRare;
  public string cardMapKey;
  public CardTypeMap.CardKeyEnum cardKey;
  public CardCoverRect cardCoverRect;
  public object Clone()
  {
    Card cloneCard = (Card)MemberwiseClone();
    cloneCard.cardKey = CardTypeMap.MapKeyToCardKey(cloneCard.cardMapKey);
    cloneCard.id = RandomID.GetRandomId(); // 后期改为随机生成的ID
    return cloneCard;
  }
}

public class CardCoverRect
{
  public int posX;
  public int posY;
  public int width;
  public int height;
  public Image.Type imageType; // 0-Simple  1-Sliced  2-Tiled  3-Filled
}

public class CardSlots
{
  public int cardType0 = 0;
  public int cardType1 = 0;
  public int cardType2 = 0;
  public int cardType3 = 0;
  public int cardType4 = 0;
  public int cardType5 = 0;
  public Dictionary<CardTypeMap.CardTypeEnum, int> CardSlotsDictionary = null;
  public Dictionary<CardTypeMap.CardTypeEnum, int> getExistCardSlot()
  {
    if (CardSlotsDictionary == null)
    {
      CardSlotsDictionary = new Dictionary<CardTypeMap.CardTypeEnum, int>();
      if (cardType0 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType0, cardType0);
      }
      if (cardType1 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType1, cardType1);
      }
      if (cardType2 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType2, cardType2);
      }
      if (cardType3 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType3, cardType3);
      }
      if (cardType4 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType4, cardType4);
      }
      if (cardType5 > 0)
      {
        CardSlotsDictionary.Add(CardTypeMap.CardTypeEnum.CardType5, cardType5);
      }
    }
    return CardSlotsDictionary;
  }
  public CardSlots(int cardType0, int cardType1, int cardType2, int cardType3, int cardType4, int cardType5)
  {
    this.cardType0 = cardType0;
    this.cardType1 = cardType1;
    this.cardType2 = cardType2;
    this.cardType3 = cardType3;
    this.cardType4 = cardType4;
    this.cardType5 = cardType5;
    CardSlotsDictionary = getExistCardSlot();
  }
}
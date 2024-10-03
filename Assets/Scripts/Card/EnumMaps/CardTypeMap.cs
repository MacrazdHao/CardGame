using System.Collections;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CardTypeMap
{
  public enum CardKeyEnum { Card_Default, Card_MonkeysYell, Card_SleepMonkey, Card_MoneyMonkey }
  public enum AttributeEnum { Magic, Physic, Attack, Defence, Default }
  public enum CardTypeEnum { CardType0, CardType1, CardType2, CardType3, CardType4, CardType5, Default }
  public enum CardRareEnum { B, A, S, SS, SSR, UR }

  public static string CardKeyToMapKey(CardKeyEnum val)
  {
    switch (val)
    {
      case CardKeyEnum.Card_Default: return "Card_Default";
      case CardKeyEnum.Card_MonkeysYell: return "Card_MonkeysYell";
      case CardKeyEnum.Card_MoneyMonkey: return "Card_MoneyMonkey";
      case CardKeyEnum.Card_SleepMonkey: return "Card_SleepMonkey";
      default: return "Card_Default";
    }
  }
  public static CardKeyEnum MapKeyToCardKey(string cardKey)
  {
    switch (cardKey)
    {
      case "Card_Default": return CardKeyEnum.Card_Default;
      case "Card_MonkeysYell": return CardKeyEnum.Card_MonkeysYell;
      case "Card_MoneyMonkey": return CardKeyEnum.Card_MoneyMonkey;
      case "Card_SleepMonkey": return CardKeyEnum.Card_SleepMonkey;
      default: return CardKeyEnum.Card_Default;
    }
  }
  public static string AttributeEnumToMapKey(AttributeEnum val)
  {
    switch (val)
    {
      case AttributeEnum.Attack: return "Attack";
      case AttributeEnum.Defence: return "Defence";
      case AttributeEnum.Physic: return "Physic";
      case AttributeEnum.Magic: return "Magic";
      default: return "Default";
    }
  }
  public static string CardTypeEnumToMapKey(CardTypeEnum val)
  {
    switch (val)
    {
      case CardTypeEnum.CardType0: return "cardType0";
      case CardTypeEnum.CardType1: return "cardType1";
      case CardTypeEnum.CardType2: return "cardType2";
      case CardTypeEnum.CardType3: return "cardType3";
      case CardTypeEnum.CardType4: return "cardType4";
      case CardTypeEnum.CardType5: return "cardType5";
      default: return "Default";
    }
  }
  public static string CardRareEnumToMapKey(CardRareEnum val)
  {
    switch (val)
    {
      case CardRareEnum.B: return "B";
      case CardRareEnum.A: return "A";
      case CardRareEnum.S: return "S";
      case CardRareEnum.SS: return "SS";
      case CardRareEnum.SSR: return "SSR";
      case CardRareEnum.UR: return "UR";
      default: return "Default";
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CardTypeMap
{
  public enum AttributeEnum { Attack, Defence, Default }
  public enum CardTypeEnum { CardType0, CardType1, CardType2, CardType3, CardType4, CardType5, Default }
  public enum CardRareEnum { B, A, S, SS, SSR, UR }
  
  public static string AttributeEnumToMapKey(AttributeEnum val) {
    switch(val) {
      case AttributeEnum.Attack: return "Attack";
      case AttributeEnum.Defence: return "Defence";
      default: return "Default";
    }
  }
  public static string CardTypeEnumToMapKey(CardTypeEnum val) {
    switch(val) {
      case CardTypeEnum.CardType0: return "cardType0";
      case CardTypeEnum.CardType1: return "cardType1";
      case CardTypeEnum.CardType2: return "cardType2";
      case CardTypeEnum.CardType3: return "cardType3";
      case CardTypeEnum.CardType4: return "cardType4";
      case CardTypeEnum.CardType5: return "cardType5";
      default: return "Default";
    }
  }
  public static string CardRareEnumToMapKey(CardRareEnum val) {
    switch(val) {
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
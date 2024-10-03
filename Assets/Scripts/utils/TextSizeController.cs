using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeController : MonoBehaviour
{
  public Text textComponent;
  public string text;
  private string textBuffer;
  public float textPreferredWidth;
  private RectTransform textRectTransform;
  public Action<TextSizeController> OnUpdated;

  void Start()
  {
    textComponent = GetComponent<Text>();
    textRectTransform = textComponent.GetComponent<RectTransform>();
    if (text != null)
    {
      textComponent.text = text;
    }
    else
    {
      text = textComponent.text;
    }
    textBuffer = text;
    // 自适应宽度
    textPreferredWidth = textComponent.preferredWidth;
    textRectTransform.sizeDelta = new Vector2(textPreferredWidth, textRectTransform.sizeDelta.y);
    if (OnUpdated != null)
    {
      OnUpdated(this);
      OnUpdated = null;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (text != textBuffer)
    {
      if (text != null)
      {
        textComponent.text = text;
      }
      else
      {
        text = textComponent.text;
      }
      textBuffer = text;
      // 自适应宽度
      textPreferredWidth = textComponent.preferredWidth;
      textRectTransform.sizeDelta = new Vector2(textPreferredWidth, textRectTransform.sizeDelta.y);
      if (OnUpdated != null)
      {
        OnUpdated(this);
        OnUpdated = null;
      }
    }
  }
}

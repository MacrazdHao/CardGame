using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDescriptionController : MonoBehaviour
{
    public string CardId = null;
    public string CardIdBuffer;
    public Card CardInfo;
    private Text DescriptionText;
    // Start is called before the first frame update
    void Start()
    {
        DescriptionText = transform.GetComponentInChildren<Text>();
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
        DescriptionText.text = CardInfo.cardDescription;
    }
}

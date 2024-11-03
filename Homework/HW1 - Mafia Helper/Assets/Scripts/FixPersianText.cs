using UnityEngine;
using System.Collections;
using ArabicSupport;
using UnityEngine.UI;

public class FixPersianText : MonoBehaviour
{
    public bool showTashkeel = true;
    public bool useHinduNumbers = true;

    void Start()
    {
        Text text = gameObject.GetComponent<Text>();

        string fixedText = ArabicFixer.Fix(text.text, showTashkeel, useHinduNumbers);

        gameObject.GetComponent<Text>().text = fixedText;
    }
}

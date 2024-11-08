using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class RoleUIManager : MonoBehaviour
{
    public GameObject nameText;
    public GameObject teamText;
    public GameObject roleImage;

    public bool showTashkeel = true;
    public bool useHinduNumbers = true;

    void Start()
    {
        var role = Deck.Instance.Deal();

        nameText.GetComponent<Text>().text = ArabicFixer.Fix(role.Name, showTashkeel, useHinduNumbers);
        teamText.GetComponent<Text>().text = ArabicFixer.Fix(role.Team, showTashkeel, useHinduNumbers);
        roleImage.GetComponent<RawImage>().texture = role.Texture;
    }

}

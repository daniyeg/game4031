using UnityEngine;
using UnityEngine.UI;

public class RoleUIManager : MonoBehaviour
{
    public GameObject nameText;
    public GameObject teamText;
    public GameObject roleImage;

    void Start()
    {
        var role = Deck.Instance.Deal();

        nameText.GetComponent<Text>().text = role.Name;
        teamText.GetComponent<Text>().text = role.Team;
        roleImage.GetComponent<RawImage>().texture = role.Texture;
    }

}

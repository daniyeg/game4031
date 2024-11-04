using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnMainMenuPress()
    {
        SceneManager.LoadScene("SelectModeMenu");
    }

    public void OnWaitScreenPress()
    {
        SceneManager.LoadScene("RoleScreen");
    }

    public void OnRoleScreenPress()
    {
        SceneManager.LoadScene("WaitScreen");
    }

    public void OnEightPlayerPress()
    {
        Deck.Instance.ResetDeck(8);
        SceneManager.LoadScene("WaitScreen");
    }

    public void OnTenPlayerPress()
    {
        Deck.Instance.ResetDeck(10);
        SceneManager.LoadScene("WaitScreen");

    }

    public void OnTwelvePlayerPress()
    {
        Deck.Instance.ResetDeck(12);
        SceneManager.LoadScene("WaitScreen");
    }
}

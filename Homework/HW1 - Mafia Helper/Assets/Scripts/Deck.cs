using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private static Deck instance;
    private static List<Role> roles = new List<Role>();

    public static Deck Instance
    {
        get { return instance; }
    }

    public static int RolesRemaining
    {
        get { return roles.Count; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AddRoleToDeck(string roleName)
    {
        Debug.Log($"Role {roleName} Added to the deck.");
        var role = Role.RolesDictionary[roleName]();
        roles.Add(role);
    }

    private void InitializeDeck(int playerCount)
    {
        switch (playerCount)
        {
            default:
            case 12:
                AddRoleToDeck("Civilian");
                AddRoleToDeck("Murderer");
                goto case 10;
            case 10:
                AddRoleToDeck("Civilian");
                AddRoleToDeck("Mayor");
                goto case 8;
            case 8:
                AddRoleToDeck("Godfather");
                AddRoleToDeck("Mafioso");
                AddRoleToDeck("Proffesional");

                AddRoleToDeck("Detective");
                AddRoleToDeck("Doctor");
                AddRoleToDeck("Sniper");
                AddRoleToDeck("Civilian");
                AddRoleToDeck("Civilian");
                break;
        }
    }

    private void Shuffle()
    {
        System.Random rand = new System.Random();
        int n = roles.Count;
        while (n > 1)
        {
            int k = rand.Next(n--);
            var temp = roles[n];
            roles[n] = roles[k];
            roles[k] = temp;
        }
    }

    public Role Deal()
    {
        if (roles.Count == 0)
        {
            return null;
        }

        Role dealtRole = roles[0];
        roles.RemoveAt(0);
        return dealtRole;
    }

    public void ClearDeck()
    {
        if (roles != null)
        {
            roles.Clear();
        }
    }

    public void ResetDeck(int playerCount)
    {
        ClearDeck();
        InitializeDeck(playerCount);
    }
}

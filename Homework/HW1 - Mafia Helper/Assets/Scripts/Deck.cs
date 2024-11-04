using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Role> roles;

    public Deck(int playerCount)
    {
        roles = new List<Role>();
        InitializeDeck(playerCount);
        Shuffle();
    }

    private void InitializeDeck(int playerCount)
    {
        switch (playerCount)
        {
            case 8:
                break;

            case 10:
                break;

            case 12:
            default:
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
}

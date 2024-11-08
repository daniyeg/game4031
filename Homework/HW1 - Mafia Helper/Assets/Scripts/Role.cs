using System;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    public string Name;
    public string Team;
    public string Description;
    public Texture Texture;

    public Role(string name, string team, string description, string texturePath)
    {
        Name = name;
        Team = team;
        Description = description;
        Texture = Resources.Load<Texture>(texturePath);
        if (Texture == null)
        {
            Debug.LogError($"Failed to load texture {texturePath}.");
        }
    }

    public static Dictionary<string, Func<Role>> RolesDictionary = new Dictionary<string, Func<Role>>()
    {
        ["Godfather"] = () => new Role("پدرخوانده", "مافیا", "", ""),
        ["Mafioso"] = () => new Role("مافیای ساده", "مافیا", "", ""),
        ["Proffesional"] = () => new Role("حرفه‌ای", "مافیا", "", ""),
        ["Murderer"] = () => new Role("قاتل", "مافیا", "", ""),

        ["Detective"] = () => new Role("کارآگاه", "شهروند", "", ""),
        ["Doctor"] = () => new Role("دکتر", "شهروند", "", ""),
        ["Sniper"] = () => new Role("اسنایپر", "شهروند", "", ""),
        ["Civilian"] = () => new Role("شهروند ساده", "شهروند", "", ""),
        ["Mayor"] = () => new Role("شهردار", "شهروند", "", "")
    };
}

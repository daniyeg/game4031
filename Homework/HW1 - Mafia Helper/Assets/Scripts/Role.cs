using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    public string Name;
    public string Team;
    public string Description;
    public Texture2D Texture;

    public Role(string name, string team, string description, string texturePath)
    {
        Name = name;
        Team = team;
        Description = description;
        byte[] fileData = File.ReadAllBytes(texturePath);
        Texture = new Texture2D(2, 2);
        Texture.LoadImage(fileData);
        if (Texture == null)
        {
            Debug.LogError($"Failed to load texture {texturePath}.");
        }
    }

    public static Dictionary<string, Func<Role>> RolesDictionary = new Dictionary<string, Func<Role>>()
    {
        ["Godfather"] = () => new Role("پدرخوانده", "مافیا", "", "Assets/Sprites/godfather.jpg"),
        ["Mafioso"] = () => new Role("مافیای ساده", "مافیا", "", "Assets/Sprites/mafia.jpg"),
        ["Proffesional"] = () => new Role("حرفه ای", "مافیا", "", "Assets/Sprites/mafia.jpg"),
        ["Murderer"] = () => new Role("قاتل", "مافیا", "", "Assets/Sprites/mafia.jpg"),

        ["Detective"] = () => new Role("کارآگاه", "شهروند", "", "Assets/Sprites/detective.jpg"),
        ["Doctor"] = () => new Role("دکتر", "شهروند", "", "Assets/Sprites/doctor.jpg"),
        ["Sniper"] = () => new Role("اسنایپر", "شهروند", "", "Assets/Sprites/sniper.jpg"),
        ["Civilian"] = () => new Role("شهروند ساده", "شهروند", "", "Assets/Sprites/civilian.jpg"),
        ["Mayor"] = () => new Role("شهردار", "شهروند", "", "Assets/Sprites/mayor.jpg")
    };
}

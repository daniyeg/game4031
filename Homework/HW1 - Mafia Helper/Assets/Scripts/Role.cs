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
}

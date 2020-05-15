using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    // Start is called before the first frame update
    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue ()
    {
        int finalValue = baseValue;
        //mirar modifiers
        return finalValue;
    }

    public void AddModifier (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}

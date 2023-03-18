using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*------------------------------------------------------------------------
Documentation

Update: Initial Creation

Date: 18-3-2023

Changes:
    Added:
        Class:
            class Char_Stats        :   container for the characters every stat
                public string Race              :   race indicator cariable
                public float Base_Movespeed     :   variable that dictates the speed of the character
                public float Base_Size          :   variable that dictates the size of the character
        
        Setters:
            set_Base_Movespeed(float movespeed) :   sets the movespeed of the character
            set_Base_Size(float size)           :   sets the size of the character


------------------------------------------------------------------------*/

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Char_Stats", order = 1)]
public class Char_Stats : ScriptableObject
{

    /* currently unrelevant variables
    //stagger stats
    public float Base_Weight;
    public float Base_Max_Stagger;
    public float Base_Initial_Stagger;
    public float Base_Succeeding_Stagger;
    public float Base_Stagger_Delay;
    public float Base_Stagger_Decrement;
    public float Base_Max_Recovery;
    public float Base_Recovery_Damage;
    public float Base_Recovery;

    //spell stats
    public float Base_Cooldownreduction;
    public float Base_Spell_Damage;
    public float Base_Spell_Size;
    public float Base_Spell_Duration;
    */

    //race indicator : 0 for default, succeeding races are indexed after 0
    public string Race;

    //general stats
    public float Base_Movespeed;
    public float Base_Size;


    //private readonly List<Stat_Modifier> stat_mod;

    public Char_Stats(string race)
    {
        Race = race;

        set_Base_Movespeed(100);
        set_Base_Size(100);

        //stat_mod = new List<Stat_Modifier>
    }

    //Setters
    //only created the relevant stats for now
    public void set_Base_Movespeed(float movespeed)
    {
        Base_Movespeed = movespeed;
    }

    public void set_Base_Size(float size)
    {
        Base_Size = size;
    }
}


/*
public class Stat_Modifier
{
        //general stats
    public readonly float Base_Movespeed;
    public readonly float Base_Size;

    //stagger stats
    public readonly float Mod_Weight;
    public readonly float Mod_Max_Stagger;
    public readonly float Mod_Initial_Stagger;
    public readonly float Mod_Succeeding_Stagger;
    public readonly float Mod_Stagger_Delay;
    public readonly float Mod_Stagger_Decrement;
    public readonly float Mod_Max_Recovery;
    public readonly float Mod_Recovery_Damage;
    public readonly float Mod_Recovery;

    //spell stats
    public readonly float Mod_Cooldownreduction;
    public readonly float Mod_Spell_Damage;
    public readonly float Mod_Spell_Size;
    public readonly float Mod_Spell_Duration;
    
    public Stat_Modifier(float value)
    {
        Value = value;
    }
}
*/

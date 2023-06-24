using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;
using UnityEngine.Pool;

public class SpellManager : MonoBehaviour
{
    
    //Spell Game Objects : Assign respective spells here
    public GameObject FireballSpell;    
    public GameObject PoolSpell;
    public GameObject SpikeSpell;
    public GameObject GustSpell;
    public GameObject RaySpell;
    [SerializeField] GameObject LightningSpell;
    [SerializeField] GameObject DeathSpell;


    void Start()
    {
        FireballSpell.GetComponent<Spell_Fireball>().enabled = false;

        ForceDisable(FireballSpell);
        ForceDisable(PoolSpell);
        ForceDisable(SpikeSpell);
        ForceDisable(GustSpell);
        ForceDisable(RaySpell);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Toggle(FireballSpell);
            //Toggle(PoolSpell);
            //Toggle(SpikeSpell);
            //Toggle(GustSpell);
            //Toggle(RaySpell);
            Toggle(SpikeSpell);
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Toggle(GustSpell);
        }

        //else if (Input.)

    }

    private void Toggle(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    private void ForceDisable(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }

    private void ForceEnable(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}

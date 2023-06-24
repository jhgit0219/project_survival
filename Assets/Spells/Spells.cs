using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spells : MonoBehaviour
{
    //private float duration = SpellManager.
    //[SerializeField] GameObject spell;

    //public Transform spellBody;

    //[SerializeField] protected float Duration { get; set; }
    [SerializeField] protected float Damage { get; set; }
    [SerializeField] protected float Size { get; set; }
    [SerializeField] protected float Speed { get; set; }
    // [SerializeField] protected float Cooldown { get; set; }

    //[SerializeField] protected float elapsedTime { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}

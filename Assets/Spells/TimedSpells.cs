using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class TimedSpells : Spells
{
    [SerializeField] protected float Duration { get; set; }
    protected float ElapsedTime { get; set; }
    protected float Cooldown { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpellCountdown();
    }

    protected virtual void Countdown()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Cooldown)
        {
            ElapsedTime = 0;
            CastSpell();
        }
    }

    protected abstract void CastSpell();

}

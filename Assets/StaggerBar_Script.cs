using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerBar_Script : MonoBehaviour
{

    //Stagger Variable
    public float Current_Stagger { get;private set; }
    public float Initial_Stagger { get; private set; }
    public float Succeeding_Stagger { get; private set; }
    public float Max_Stagger { get; private set; }
    public float Time_Since_Stagger { get; private set; }
    public float Decay_Value_Stagger { get; private set; }
    public float Delay_Stagger { get; private set; }

    //Recovery Variables
    public float Current_Recovery { get; private set; }
    public float Max_Recovery { get; private set; }
    public float Damage_Recovery { get; private set; }
    public float DecayPerSec_Recovery { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time_Since_Stagger < 3600) { Time_Since_Stagger += Time.deltaTime; }

        //checks to see if enough time has passed and the current stagger is large enough for decaying
        DecayStagger();

    }

    //checks if collision is hostile and then applies stagger based on current stagger
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            Stagger();
        }
    }


    public void DecrementStagger(float value) { this.Current_Stagger -= value; }
    public void DecrementRecovery(float value) { this.Current_Recovery -= value; }

    public void DecayStagger()
    {
        if (Time_Since_Stagger >= Delay_Stagger)
        {
            if ((Current_Stagger - (Decay_Value_Stagger * Time.deltaTime)) > 0)
            {
                Current_Stagger = -Decay_Value_Stagger * Time.deltaTime;
            }

            else
            {
                Current_Stagger = 0;
            }
        }
    }

    public void Stagger()
    {
        if (Current_Recovery <= 0)
        {
            //Check if this is not the first stagger
            if (Current_Stagger >= 0 && Current_Stagger < Max_Stagger)
            {
                Current_Stagger += Succeeding_Stagger;
            }

            //Check if stagger does not go over maximum
            else if ((Current_Stagger + Succeeding_Stagger) < Max_Stagger)
            {

                Current_Stagger = Initial_Stagger;
            }

            //maxes stagger and initializes recovery when stagger would be full
            else
            {
                Current_Stagger = Max_Stagger;
                Current_Recovery = Damage_Recovery;
            }

            //reset time since stagger
            Time_Since_Stagger = 0;
        }

        //fill up recovery bar
        else
        {
            if ((Current_Recovery + Damage_Recovery) < Max_Recovery)
            {
                Current_Recovery += Damage_Recovery;
            }

            else { OnCharDeath(); }
         }
    }

    public void OnCharDeath()
    {

    }
}

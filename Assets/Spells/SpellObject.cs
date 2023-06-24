using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellObject : MonoBehaviour
{
    [SerializeField] protected float Duration { get; set; }
    [SerializeField] protected float ElapsedTime { get; set; }
    [SerializeField] protected float Size { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        ElapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //SpellCountdown();
    }

    public virtual void SpellCountdown()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime >= Duration)
        {
            ElapsedTime = 0f;
            Destroy(gameObject);
        }

    }
}

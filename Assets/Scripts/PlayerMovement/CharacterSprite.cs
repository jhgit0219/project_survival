using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterSprite : MonoBehaviour
{

    protected CharacterSprite character;

    [HideInInspector]
    public bool isFacingLeft;

    public bool spawnFacingLeft = true;
    private Vector2 facingLeft;

    private void Start()
    {
        Initialization();        
    }
    protected virtual void Initialization()
    {
        character = GetComponent<CharacterSprite>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }
    }

    protected virtual void Flip()
    {
        if (isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        if (!isFacingLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}

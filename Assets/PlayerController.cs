using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Transform player;
    public float moveSpeed = 0f;
    public float turnValue = 0f;


    //controls simulator
    public float moveDirectionX = 0f;
    public float moveDirectionY = 0f;
    
    public float circleVal = 0f;

    //private Vector2 joystickDirection = new Vector2(1f, 1f);
    private Vector2 joystickDirection;


    // Update is called once per frame
    private void Update()
    {
        if (joystickDirection == Vector2.zero)
        {
            // Move the player based on the joystick direction
            //player.Translate(joystickDirection * moveSpeed * Time.deltaTime);
            
            player.Translate(new Vector2(Mathf.Cos(circleVal), Mathf.Sin(circleVal)) * moveSpeed * Time.deltaTime);
            //player.position = player.position + new Vector2(moveDirectionX, moveDirectionY);
        }

        if (circleVal < 360) {circleVal += turnValue * Time.deltaTime;}

        else {circleVal = 0;}

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the direction of the joystick
        Vector2 joystickPos = eventData.position - (Vector2)transform.position;
        joystickDirection = joystickPos.normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Called when the joystick is pressed
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Called when the joystick is released
        joystickDirection = Vector2.zero;
    }
}
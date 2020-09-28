using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{

    static float Speed = 2.0f;

    static float AngularSpeed = 100.0f;


    public List<KeyCode> UpButton;
    public List<KeyCode> DownButton;
    public List<KeyCode> LeftButton;
    public List<KeyCode> RightButton;

    public static Vector3 PlayerPosition;

    private void Awake()
    {
        PlayerPosition = transform.position;
    }


    void FixedUpdate()
    {
        Rotation();
        Movement();
    }


    void Rotation()
    {
        float movement = 0;
        movement += MoveIfPressed(LeftButton, -1);
        movement += MoveIfPressed(RightButton, 1);
        if (movement != 0)
        {
            this.transform.Rotate(new Vector3(0, movement, 0) * Time.fixedDeltaTime * AngularSpeed, Space.World);
        }   
    }

    void Movement()
    {
        float movement = 0;
        movement += MoveIfPressed(UpButton, 1);
        movement += MoveIfPressed(DownButton, -1);
        if (movement != 0)
        {
            this.transform.Translate(new Vector3(0, 0, movement) * Time.fixedDeltaTime * Speed, Space.Self);
        }
    }


    float MoveIfPressed(List<KeyCode> keyList, float movement)
    {
        //ChecK Buttons from list
        foreach (KeyCode element in keyList)
        {
            if (Input.GetKey(element))
            {
                return movement;
            }
        }
        return 0;
    }

    public static void InitializeThis(float speed, float angularSpeed)
    {
        Speed = speed;
        AngularSpeed=angularSpeed;
    }


}

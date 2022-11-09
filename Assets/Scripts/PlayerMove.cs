using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSPD = 5f;

    public Rigidbody2D rigidbody2D;
    public Camera cam;

    private Vector2 mousePos;
    private Vector2 movement;

    // pegando input do user
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //lendo posição do mouse na tela e convertendo para ingame logic
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    //lidando com a física
    private void FixedUpdate()
    {
        //movendo na tela 2d
        rigidbody2D.MovePosition(rigidbody2D.position + moveSPD * Time.fixedDeltaTime * movement);

        //calculando o vetor de mira
        Vector2 lookdir = mousePos - rigidbody2D.position;
        //calculando o arcotangente do vetor e ajeitando a posição dele
        float angle = Mathf.Atan2(lookdir.y, lookdir.x)*Mathf.Rad2Deg - 90f;
        //efetivamente rodando o corpo
        rigidbody2D.rotation = angle;

    }


}

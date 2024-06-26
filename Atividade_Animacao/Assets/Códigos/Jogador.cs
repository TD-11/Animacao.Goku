using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody2D rig;

    private Animator anim;
    
    public bool noChao;

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Chao" && !noChao)
        {
            noChao = true;
        }
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = Vector2.right * velocidade;
            anim.SetBool("EstarAndando", true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = Vector2.left * velocidade;
            anim.SetBool("EstarAndando", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }
        else
        {
            anim.SetBool("EstarAndando", false);
        }
        
        if (Input.GetKey(KeyCode.Space) && noChao)
        {
            anim.SetBool("EstarPulando", true);
            anim.SetBool("EstarAndando", false);
            
            rig.velocity = Vector2.up * velocidade;
            noChao = false;
        }
        else if(noChao == true)
        {
            anim.SetBool("EstarPulando", false);
        }
        
        if (Input.GetKey(KeyCode.L))
        {
            anim.SetBool("EstarAtacando", true);
            
        }
        else
        {
            anim.SetBool("EstarAtacando", false);
        }

    }
}


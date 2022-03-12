using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {
    GameObject jogadorFelpudo;
    bool marcouPonto;
	// Use this for initialization
	void Start () {
        //quando o objeto e criado o objeto e deslocada para a esquerda
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        //invocar o jogador pela tag:player
        jogadorFelpudo = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //destruir o inimigo sempre que ele ultrapassar a margem esquerda x do ecra;
        if(transform.position.x < -25)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //marcar pontos:sempre que o inimigo ultrapassar a posicao do jogador
            if(transform.position.x < jogadorFelpudo.transform.position.x)
            {
                if(!marcouPonto)
                {
                    //marcar ponto
                    marcouPonto = true;
                    //recebe velocidade
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 5.0f);
                    //desligar is kinematic para o objeto ser afetado pelo addtorque
                    GetComponent<Rigidbody2D>().isKinematic = false;
                    //adicionar rotacao descoltrolada ao jogador
                    GetComponent<Rigidbody2D>().AddTorque(-50f);
                    //alterar a cor do objeto jogador
                    GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);
                    //sendmessage serve para enviar um pedido de execucao a outra class sempre que um comporrtamento
                    //do gameobject jogadorfelpudo ocorrer
                    //executa a funcao marcarponto() o script controlajogador()
                    jogadorFelpudo.SendMessage("MarcarPontos");
                }
            }
        }
		
	}
}

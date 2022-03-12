using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour {
    //variaveis globais
    private float larguratela;

	// Use this for initialization
	void Start () {
        //fisica e adicionada ao componente rigidbody.
        //para afetar a velocidade do componente a propriedade velocity
        //alteramos os parametros de deslocamento para (-3(desloca-se para a esquerda))
        GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
        //obter altura e largura de uma imagem
        SpriteRenderer grafico = GetComponent<SpriteRenderer>();
        //obter a largura e altura da imagem
        float larguraimagem = grafico.sprite.bounds.size.x;
        float alturaimagem = grafico.sprite.bounds.size.y;
        //print (larguraimagem);
        //print (alturaimagem);
        //para calcular a altura de tela podemos utilizar a propriedade ortograficSize da camara
        //a propriedade ortograficsize devolve metade da altura da tela
        //assim se multiplicarmos por 2 obtemos a altura da tela
        float alturatela = Camera.main.orthographicSize * 2f;
        //a largura da tela e obtida da seguinte forma
        larguratela = (alturatela / Screen.height) * Screen.width;
        //redimensionar a imagem para a dimensao da tela
        //obter a escala atual da tela
        Vector2 novaescala = transform.localScale;
        //redimensionar a imagem
        //para garantir que a segunda imagem inicia exatamente a seguir a primeira precisamos de adicionar a escala um valor de correcao 0.25f
        novaescala.x = (larguratela / larguraimagem) + 0.25f;
        novaescala.y = (alturatela / alturaimagem);
        //atribuir a nova escala
        transform.localScale = novaescala;
        //colocar a segunda imagem em posicao inicial
        if(this.name =="imgFundoB")
        {
            //posicionar a imagem de fundo b no final da primeira imagem A
            transform.position = new Vector2(larguratela, 0f);
        }

    }

    // Update is called once per frame
    void Update () {
		//sempre que a posicao da imagem em x for
        //menor ou igual a largura da tela altera a posicao para o inicio da tela
        //assim obtemos a continnuidade da imagem
        if(transform.position.x <= -larguratela)
        {
            transform.position = new Vector2(larguratela, 0f);
        }
	}
}

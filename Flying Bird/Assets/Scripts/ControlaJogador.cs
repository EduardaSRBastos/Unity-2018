using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {
    //comeacar e terminar o jogo
    bool comecou;
    bool acabou;
    public bool gravidade;
    //corpo do jogador
    Rigidbody2D corpojogador;
    Vector2 forcaimpulso = new Vector2(0, 500f);
    //variavel que vai receber como parametro o sistema de particulas
    //particulapenas
    public GameObject particulapenas;
    //obter o objeto gameengine
    GameObject gameEngine;
    //pontuacao estado inicial
    public Text pontuacao;
    //contador (pontuacao)
    int contador;
	// Use this for initialization
	void Start () {
        //carregar o gameobject gameengine quando iniciar o jogo atraves
        //da tag da camara onde adicionou o script gameengine
        gameEngine = GameObject.FindGameObjectWithTag("MainCamera");
        //corpo do jogador recebe um novo componente
        corpojogador = GetComponent<Rigidbody2D>();
        //posicao do texto na cena e propriedades iniciais
        pontuacao.transform.position = new Vector2(Screen.width / 2, Screen.height - 300);
        pontuacao.text = "Toque para iniciar!";
        pontuacao.fontSize = 36;
	}
	
	// Update is called once per frame
	void Update () {
        if (!acabou)
        {
            //fire1 e um nome padrao do unity e refere-se ao botao esquerdo do rato
            if (Input.GetButtonDown("Fire1"))
            {
                if (!comecou)
                {
                    //comecar jogo
                    comecou = true;
                    //desliga iskinematic
                    corpojogador.isKinematic = false;
                    //posicao do texto na cena e propriedades iniciais
                    pontuacao.transform.position = new Vector2(Screen.width / 2, Screen.height - 100);
                    pontuacao.text = contador.ToString();
                    pontuacao.fontSize = 50;
                    //inocar o metodo comecou do script associado a camara
                    gameEngine.SendMessage("Comecou");
                }
                //velocidade=0
                corpojogador.velocity = new Vector2(0, 0);
                //adicionar impulso inicial ao jogador
                corpojogador.AddForce(forcaimpulso);
                //instanciar o objeto particula como gameobject particula
                GameObject particula = Instantiate(particulapenas);
                //para centrar melhor a emissao das particulas relativamente do jogador
                Vector3 posicaojogador = this.transform.position + new Vector3(0, 1, 0);
                //particula e inicado na posicao atual do jogador
                particula.transform.position = posicaojogador;
            }
            //verificar se o utilizar ultrapassou os limites da cena:
            //e necessario converter as unidades unity para pixels
            float alturajogadorempixels = Camera.main.WorldToScreenPoint(transform.position).y;
            if (alturajogadorempixels > Screen.height || alturajogadorempixels < 0)
            {
                //destruir o jogador           
                //Destroy(this.gameObject);
                DestroiJogador();
                Fimdejogo();
            }
            //quaternion e utilizado para representar rotacao. a rotacao e dada no eixo z
            //a velocidade do jogador e multiplicada por 2 para reforcar
            //a velocidade do jogador e transferida para a rotacao do objeto
            transform.rotation = Quaternion.Euler(0, 0, corpojogador.velocity.y * 2);
        }
    }
    //metodo que verifica colisoes em 2d
    void OnCollisionEnter2D()
    {
        if (!acabou)
        {
            acabou = true;
            DestroiJogador();
            Fimdejogo();
        }
    }
    //se colidir entao destroi o jogador
    void DestroiJogador()
    {
        //desligar as colisoes
        GetComponent<Collider2D>().enabled = false;
        //para a velocidade do jogo
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //fazer o jogador saltar para a esquerda
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
        //adicionar a rotacao descontrolada ao jogador
        GetComponent<Rigidbody2D>().AddTorque(300f);
        //alterar a cor do objeto jogador
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.75f, 0.75f);
    }
    void MarcarPontos()
    {
        //pontuacao +=1
        contador++;
        //atualizar pontuacao
        pontuacao.text = contador.ToString();
    }
    void Fimdejogo()
    {
        //invocar o metodo recarregarcena 2 segundos depois
        Invoke("RecarregarCena", 2);
        //invocar o metodo acabou do script associado a camara
        gameEngine.SendMessage("Acabou");
    }
    void RecarregarCena()
    {
        //recarregar cena se nao funvionar utilizar a versao em baixo
        //screne manager utiliza a biblioteca using unity.engine.scenemanagement;
        SceneManager.LoadScene("Game");
        //versao obsolere eesta
        //application.loadlevel("Game");
    }
}

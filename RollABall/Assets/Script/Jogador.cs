using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {
    //Mais info da class Input: https://docs.unity3d.com/ScriptReference/Input.html
    //Mais info da class Input: https://docs.unity3d.com/ScriptReference/Rigidbody.html
    //Mais info da class Input: https://docs.unity3d.com/ScriptReference/Vecotr3.html
    //A variável é declarada como pública (variáveis declaradas como públicas são adicionadas como propriedades do componente)
    //quando adicionamos variáveis como publicas podemos fazer alterações diretamente no editor
    //Variável de controlo de velocidade é adicionada como propriedade do componente (script)
    public float velocidade;
    //Variável de controlo do componente RigidBody do objeto de jogo que estamos a programar
    //Esta variável vai guardar uma referência do componente a que queremos ter acesso
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        //Física é adicionada ao componente Rigidbody
        //Guardar a referência do objeto Rigidbody (se este existir)
        rb = GetComponent<Rigidbody>();
        //inicializar a variavel contador com valor
        contador = 0;
        //adicionar valor a variavel contar
        Contador();
        //o texto de vitoria deve iniciar sem valor
        vitoria.text = "";
	}
	//O método FixedUpdate é chamado antes de ser efetuado qualquer cálculo de física.
    //Física deve ser adicionada neste método

	void FixedUpdate () {
        //Variáveis que vão armazenar a posição do jogador
        //A função GetAxis permite aceder ao eixo que queremos manipular
        float moverNaHorizontal = Input.GetAxis("Horizontal");
        float moverNaVertical = Input.GetAxis("Vertical");

        //Rigidbody Vector3 guarda as coordenadas nos eixos em 3D(x,y,z)
        //como não queremos movimento no eixo do y configuramos da seguinte forma 0.0f
        Vector3 movimento = new Vector3(moverNaHorizontal, 0.0f, moverNaVertical);
        //Método AddForce permite adicionar uma força ao objeto que neste caso é
        //movimento * velocidade
        rb.AddForce(movimento );
    }
    //evento OntriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        //se o gameobject for um coletavel
        if(other.gameObject.CompareTag("Coletavel"))
        {            
            //entao desativa
            other.gameObject.SetActive(false);
            //quando a colisao e detetada entao
            contador = contador + 1;
            //adicionar valor a variavel contar
            Contador();
        }
    }  
    //variavel contador
    private int contador = 0;
    //variavel para suporte do contador
    public Text contar;
    //metodo contador a propriedade texto de contar
    //escreve contador : contador
    void Contador()
    {
        contar.text = "Contador: " + contador.ToString();
        //se o contador for maior ou igual ao numero de coletaveis
        //entao executa
        if(contador >=12)
        {
            vitoria.text = "Ganhou! Parabéns";
        }
    }
    //variavel para suportar o texto de vitoria
    public Text vitoria;
}

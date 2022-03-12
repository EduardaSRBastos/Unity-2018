using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    //criar uma propriedade que recebe o objeto inimigo
    public GameObject inimigo;
	// Use this for initialization
	void Comecou () {
        //script responsavel pela criacao do inimigo
        //metodo invokerepeating invocar o inimigo de x em x tempo
        //recebe 3 parametros nomemetodo(string), time(float), repeatrate(float)
        InvokeRepeating("CriarInimigo", 0.5f, 1.5f);
	}
	void CriarInimigo()
    {
        //obter valor random de -5 a5
        //random.value devolve um valor de 0.0 a 1
        float alturaAleatoria = 10.0f * Random.value - 5;
        //criar novas instancias do inimigo
        GameObject novoInimigo = Instantiate(inimigo);
        //o objeto e criado fora da cena "visivel" em x e uma altura aletatoria em y entre 5 e -5
        novoInimigo.transform.position = new Vector2(15.0f, alturaAleatoria);
    }
	// Update is called once per frame
	void Update () {
		
	}
    void Acabou()
    {
        //terminar a criacao de inimigo
        CancelInvoke("CriarInimigo");
    }
}

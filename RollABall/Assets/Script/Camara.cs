using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    //Mais info sobre GameObject: https://docs.unity3d.com/ScriptReference/GameObject.html
    //Vamos criar uma propriedade para o nosso script chamada jogador
    //a propriedade é publica e é do tipo GameObject (permite referenciar um objeto do nosso jogo)
    public GameObject jogador;
    //variável privado pois podemos definir o valor diretamente no nosso codigo sem precisar de reajustar
    //vai subtrair a posicao do jogador a posicao atual da camara
    //para encontrar a diferenca entre os dois
    private Vector3 offset;
	// Use this for initialization
	void Start() {
        //no inicio vamos subtrair a posicao do jogador a posicao atual da camara
        offset = transform.position - jogador.transform.position;
	}
    //Para a camara utilizamod o método LateUpdate
    //Desta forma garantimos que a camara so e movimentada
    //depois de todos os outros componentes do jogo sofrerem modificaçoes (movimento)
    //as camaras que seguem outros objetos devem ser configuradas no metodo LateUpdate()

	// Update is called once per frame
	void LateUpdate() {
        //quando atualizar a posicao do jogador a camara é movimentada para uma nova posicao
        //perfeitamente alinhada com o jogador
        transform.position = jogador.transform.position + offset;
	}
}

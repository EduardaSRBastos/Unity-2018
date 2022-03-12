using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour {

    //Mais info sobre GameObject: https://docs.unity3d.com/ScriptReference/Transform.html
    //Mais info sobre GameObject: https://docs.unity3d.com/ScriptReference/Time.html
    //Update é chamado a cada frame
    void Update () {
        //o metodo rotate aplica rotacao ao cubo a partir da origem
        //o metodo na sua forma mais simples permite aplicar rotacao de posicao invacando a class Vector3
        //para possibilitar a rotacao ao longo do tempo invocamos a class time
        //deltatime(devolve o tempo em segundo que demorou a completar a ultima frame)
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}

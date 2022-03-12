using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjeto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //invocar metodo apagar objeto de dois em dois segundos
        Invoke("ApagaObjeto", 2f);
	}
	void ApagaObjeto()
    {
        //destruir o objeto
        Destroy(this.gameObject);
    }
	
}

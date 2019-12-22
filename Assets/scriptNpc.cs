using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNpc : MonoBehaviour {

    public GameObject alvo;
    public float velocidade = 60;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidade * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timer;
    public float contagem = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(contagem > 0.0f)
        {
            contagem -= Time.deltaTime;
            timer.text = contagem.ToString("F2");
        }
        else
        {
            timer.text = "Terminou o tempo";
        }
	}
}

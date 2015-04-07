using UnityEngine;
using System.Collections;

public class Enemy_capsule_damage : MonoBehaviour {

	public void damage() {
		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}

	// Use this for initialization
	void Start () {
//		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

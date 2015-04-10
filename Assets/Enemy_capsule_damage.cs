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

		RaycastHit hit;
		CapsuleCollider cpasCol = GetComponent<CapsuleCollider>();
//		CharacterController charCtrl = GetComponent<CharacterController>();
		Vector3 p1 = transform.position + cpasCol.center;
		if (Physics.SphereCast (p1, cpasCol.height / 2, transform.forward, out hit, 10)) {
			float distanceToObstacle = hit.distance;
			if (hit.collider.tag != "Enemy") {
				Debug.Log(this.name + " detects: " + hit.collider.tag);
			}
		}
	
	}
}

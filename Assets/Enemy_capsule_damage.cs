using UnityEngine;
using System.Collections;

public class Enemy_capsule_damage : MonoBehaviour {

	public float enemyRotationSpeed;
	public Transform target;

	private Quaternion _lookRotation;
	private Vector3 _direction;
	
	public void damage() {
		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * 2;
		Gizmos.DrawRay(transform.position, direction);
	}
	
	// Use this for initialization
	void Start () {
//		this.gameObject.GetComponent<Renderer> ().material.color = Color.red;

		enemyRotationSpeed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		CapsuleCollider cpasCol = GetComponent<CapsuleCollider>();
//		CharacterController charCtrl = GetComponent<CharacterController>();
		Vector3 p1 = transform.position + cpasCol.center;
		if (Physics.SphereCast (p1, cpasCol.height / 2, transform.forward, out hit, 2)) {
			float distanceToObstacle = hit.distance;
			if (hit.collider.tag != "Enemy") {
				Debug.Log(this.name + " detects: " + hit.collider.tag);
				target = hit.transform;

				_direction = (target.position - transform.position).normalized;
				_lookRotation = Quaternion.LookRotation(_direction);

				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * enemyRotationSpeed);

			}
		}
	
	}
}

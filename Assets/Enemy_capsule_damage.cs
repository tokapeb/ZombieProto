using UnityEngine;
using System.Collections;

public class Enemy_capsule_damage : MonoBehaviour {

	public float enemyRotationSpeed;
	public float desiredDistance;
	public Transform target;
	public float enemySpeed;

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

		enemyRotationSpeed = 6f;

		desiredDistance = 1.7f;
	}
	
	// Update is called once per frame
	void Update () {

		// Player detection part.
		RaycastHit hit;
		CapsuleCollider cpasCol = GetComponent<CapsuleCollider>();
//		CharacterController charCtrl = GetComponent<CharacterController>();
		Vector3 p1 = transform.position + cpasCol.center;
		if (Physics.SphereCast (p1, cpasCol.height / 2, transform.forward, out hit, 2)) {
			float distanceToObstacle = hit.distance;
			if (hit.collider.tag == "Player") {
//				Debug.Log(this.name + " detects: " + hit.collider.tag);
				// Turn to player part.
				target = hit.transform;

				_direction = (target.position - transform.position).normalized;
				_lookRotation = Quaternion.LookRotation(_direction);

				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * enemyRotationSpeed);

				// Follow part.
				Vector3 Diff = transform.position - target.position;
				float mult = desiredDistance / Diff.magnitude;
				transform.position -= new Vector3 (Diff.x, 0f, Diff.z);
				transform.position += new Vector3 (Diff.x, 0f, Diff.z) * mult;

			}
		}
	
	}
}

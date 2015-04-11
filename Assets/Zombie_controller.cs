using UnityEngine;
using System.Collections;

public class Zombie_controller : MonoBehaviour {

	public float movement_speed;
	public float rotate_speed;

	CharacterController Char_ctrl;
	Animator anim;
	Vector3 move_dir;
	float gravity = 9.81f;
	float runMultiplier = 1f;

	bool attacking = false;

	// Use this for initialization
	void Start () {
		Char_ctrl = GetComponent<CharacterController>();

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		float up_down_ctrl = Input.GetAxis ("Vertical");
		float left_right_ctrl = Input.GetAxis ("Horizontal");

		RaycastHit hit;

		if (Char_ctrl.isGrounded) {

			if (Input.GetKey("left shift")) {
				runMultiplier = 2f;
			} else {
				runMultiplier = 1f;
			}

			move_dir = Vector3.forward * up_down_ctrl * movement_speed * Time.deltaTime * runMultiplier;
			move_dir = transform.TransformDirection (move_dir);

			anim.SetFloat("Translation", Mathf.Abs(up_down_ctrl) * movement_speed * runMultiplier);

			if (Input.GetKey(KeyCode.Return)) {
//				attacking = true;
				anim.SetBool("Attacking", true);
				attacking = false;
				if (Physics.Raycast (transform.position, transform.forward, out hit, 100.0f)) {
					if ((hit.distance < 0.41f) && (hit.collider.tag == "Enemy")) {
						hit.collider.GetComponent<Enemy_capsule_damage>().damage();
					}
				}
			}
			
			transform.Rotate (0, left_right_ctrl * rotate_speed, 0);
		}

		move_dir.y -= gravity * Time.deltaTime;
		Char_ctrl.Move (move_dir);

		// Raycast stuff
//			Debug.Log(hit.collider); //Enemy_capsule

	}
}

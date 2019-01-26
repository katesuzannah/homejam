using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

	public float maxMoveSpeed = 1f;
	public float moveAcceleration = .1f;
	public float stopDeceleration = .5f;
	public float stopRatio = .1f;
	public Vector3 currVelocity;

    void Start()
    {
		currVelocity = new Vector3();
    }

    void Update()
    {
		Vector3 input = GetInputVec();
		Vector3 moveVec = input.sqrMagnitude > 0f ?
						  input * moveAcceleration * Time.deltaTime :
						  -1 * currVelocity * stopDeceleration * Time.deltaTime;

		currVelocity = Vector3.ClampMagnitude(currVelocity + moveVec, maxMoveSpeed);

		//if no input and curr speed under stopping ratio of max speed, stop moving
		if (input.Equals(Vector3.zero) && 
			currVelocity.sqrMagnitude <= (maxMoveSpeed * stopRatio) * (maxMoveSpeed * stopRatio))

			currVelocity = Vector3.zero;

		transform.position += currVelocity;

	}

	Vector3 GetInputVec() {
		return new Vector3(
			(Input.GetKey(KeyCode.D) ? 1 : 0) + (Input.GetKey(KeyCode.A) ? -1 : 0),
			0,
			(Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0)
		);
	}
}

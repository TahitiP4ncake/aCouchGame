using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerationScript : MonoBehaviour {

	void Update () {
        transform.Translate(Input.acceleration.x * Time.deltaTime, -Input.acceleration.z * Time.deltaTime, 0);
	}
}

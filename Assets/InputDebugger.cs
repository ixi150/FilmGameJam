using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebugger : MonoBehaviour {
	public string[] joysticks;
	void Update () {
		joysticks = Input.GetJoystickNames ();
	}
}

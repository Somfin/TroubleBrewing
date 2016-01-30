using UnityEngine;
using System.Collections;

public class PositionTo : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.WorldToScreenPoint(transform.parent.gameObject.transform.position);
	}
}

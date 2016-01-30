using UnityEngine;
using System.Collections;

public class PositionTo : MonoBehaviour {
    private GameObject child;
    public Vector3 offset;

    void Start()
    {
        this.child = gameObject.transform.parent.gameObject;
        gameObject.transform.SetParent(GameObject.Find("CameraCanvas").transform, false);
    }

	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.WorldToScreenPoint(child.transform.position) + offset;
	}
}

using UnityEngine;
using System.Collections;

public class DrunkMovement : MonoBehaviour {
    public float rotationSpeed;
    public float movementSpeed;
    public float accelleration;
    public float decelleration;
    private float stickX;
    private float stickY;

    private Vector3 previousMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.stickX = Input.GetAxis("Horizontal");
        this.stickY = Input.GetAxis("Vertical");
	}

    void FixedUpdate()
    {
        Vector3 stick = new Vector3(stickX, 0, stickY);
        Debug.DrawRay(gameObject.transform.position + Vector3.up, stick * 4, Color.red);
        Debug.DrawRay(gameObject.transform.position + Vector3.up, gameObject.transform.forward * 4, Color.blue);
        if (stick.magnitude > 0.1)
        {
            Quaternion lookRotation = Quaternion.LookRotation(stick.normalized, Vector3.up);
            Quaternion currentRotation = Quaternion.LookRotation(gameObject.transform.forward, Vector3.up);
            gameObject.transform.rotation = Quaternion.Lerp(currentRotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        var currentMove = gameObject.transform.forward * stick.magnitude * Time.deltaTime * movementSpeed;
        if (currentMove.magnitude > previousMove.magnitude)
        {
            previousMove = Vector3.Lerp(previousMove, currentMove, accelleration * Time.deltaTime);
        }
        else
        {
            previousMove = Vector3.Lerp(previousMove, currentMove, decelleration * Time.deltaTime);
        }
        gameObject.transform.Translate(previousMove, Space.World);
    }
}

using UnityEngine;
using System.Collections;

public class Lifter : MonoBehaviour {
    public string liftCommand;
    public GameObject holdPoint;
    public LiftableType[] capabilities;

    private GameObject liftedObject;
    public GameObject targetObject;
    private bool attemptingLift;
    public bool lifting;

	void Update () {
        if (Input.GetAxis(liftCommand) > 0.1 && ! attemptingLift)
        {
            attemptingLift = true;
            lifting = true;
        }
        else {
            attemptingLift = false;
        }
	}

    void FixedUpdate()
    {
        if (lifting)
        {
            if (targetObject != null)
            {
                lifting = false;
                targetObject = null;
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        Liftable liftable = c.gameObject.GetComponent("Liftable") as Liftable;
        if (liftable != null)
        {
            for (int i = 0; i < capabilities.Length; i++)
            {
                if (capabilities[i] == liftable.type)
                {
                    targetObject = c.gameObject;
                }
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        Liftable liftable = c.gameObject.GetComponent("Liftable") as Liftable;
        if (liftable != null)
        {
            if (targetObject == null || (c.gameObject.transform.position - this.gameObject.transform.position).magnitude < (this.targetObject.transform.position - this.gameObject.transform.position).magnitude)
            {
                this.targetObject = c.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject == targetObject)
        {
            targetObject = null;
        }
    }
}

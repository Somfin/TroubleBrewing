using UnityEngine;
using System.Collections;

public class Lifter : MonoBehaviour {
    public string liftCommand;
    public GameObject holdPoint;
    public LiftableType[] capabilities;

    private GameObject liftedObject;
    public GameObject targetObject;
    public GameObject targetPlacement;
    private bool attemptingLift;
    public bool lifting;

	void Update () {
        if (Input.GetAxis(liftCommand) > 0.1)
        {
            if (!attemptingLift)
            {
                lifting = true;
            }
            attemptingLift = true;
        }
        else
        {
            attemptingLift = false;
            lifting = false;
        }
	}

    void FixedUpdate()
    {
        if (liftedObject != null)
        {
            liftedObject.transform.Translate(holdPoint.transform.position - liftedObject.transform.position, Space.World);
        }
        if (lifting)
        {
            if (liftedObject != null)
            {
                bool placed = false;
                if (targetPlacement != null)
                {
                    Placeable toPlace = liftedObject.GetComponent<Placeable>();
                    if (toPlace != null){
                        Ingredient nature = toPlace.nature;
                        if (targetPlacement.GetComponent<Placement>().place(liftedObject))
                        {
                            liftedObject = null;
                            placed = true;
                        }
                    }
                }
                if (!placed)
                {
                    if (liftedObject.GetComponent<Rigidbody>() != null)
                    {
                        liftedObject.GetComponent<Rigidbody>().useGravity = true;
                    }
                    else
                    {
                        liftedObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * 1.2f;
                        liftedObject.GetComponent<CharacterController>().enabled = true;
                    }
                    liftedObject.transform.parent = null;
                    liftedObject = null;
                    lifting = false;
                }
            }
            else if (targetObject != null)
            {
                bool lift = false;
                for (int i = 0; i < capabilities.Length; i++)
                {
                    if (capabilities[i] == (targetObject.GetComponent<Liftable>()).type)
                    {
                        targetObject = targetObject.GetComponent<Liftable>().lift();
                        if (targetObject.GetComponent<Rigidbody>() != null)
                        {
                            targetObject.GetComponent<Rigidbody>().useGravity = false;
                            targetObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            targetObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        }
                        else
                        {
                            targetObject.GetComponent<CharacterController>().enabled = false;
                        }
                        targetObject.transform.parent = gameObject.transform;
                        targetObject.transform.position = holdPoint.transform.position;
                        liftedObject = targetObject;
                        targetObject = null;
                        lift = true;
                        break;
                    }
                }
                if (!lift)
                {
                    Debug.Log("Lift fail!");
                }
                else
                {
                    Debug.Log("Lift success!");
                }
                lifting = false;
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (liftedObject != null)
        {
            Placeable placeable = liftedObject.GetComponent<Placeable>();
            Placement placement = c.gameObject.GetComponent<Placement>();
            if (placeable != null && placement != null)
            {
                targetPlacement = c.gameObject;
            }
        }
        else
        {
            Liftable liftable = c.gameObject.GetComponent<Liftable>();
            if (liftable != null)
            {
                if (c.gameObject != this.gameObject && (targetObject == null || (c.gameObject.transform.position - this.gameObject.transform.forward).magnitude < (this.targetObject.transform.position - this.gameObject.transform.forward).magnitude))
                {
                    this.targetObject = c.gameObject;
                }
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (liftedObject != null)
        {
            targetPlacement = null;
        } else if (c.gameObject == targetObject)
        {
            targetObject = null;
        }
    }
}

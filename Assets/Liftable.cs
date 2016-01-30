using UnityEngine;
using System.Collections;

public class Liftable : MonoBehaviour {
    public LiftableType type;
    public GameObject stored;

    public GameObject lift()
    {
        if (stored != null)
        {
            return GameObject.Instantiate(stored);
        }
        else
        {
            return gameObject;
        }
    }
}
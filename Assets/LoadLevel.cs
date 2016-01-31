using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void Load(string LevelToLoad)
    {
        Application.LoadLevel(LevelToLoad);
    }

}

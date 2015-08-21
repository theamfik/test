using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SystemData : MonoBehaviour {

    public List<Transform> objects = new List<Transform>();
	
	void Start () {
        Transform obj;
        for (int i = 0; i < transform.childCount; i++)
        {
            obj = transform.GetChild(i);
            if (obj.tag == "Ship")
                objects.Add(obj);
        }
	}


    void Update()
    {
	
	}
}

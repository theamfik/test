using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {
    public List<Goods> items = new List<Goods>();
    

	void Start () {
        Goods item1 = new Goods("Gold", 10, 100);
        Goods item2 = new Goods("Coal", 5, 70);
        Goods item3 = new Goods("Iron", 8, 45);
        Goods item4 = new Goods("Silver", 20, 80);
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
	
	}
	

	void Update () {

       
	}
}

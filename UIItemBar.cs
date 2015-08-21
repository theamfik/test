using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIItemBar : MonoBehaviour {

    Text name;
    Text count;
    Text price;

	void Awake () {

        name = transform.GetChild(0).GetComponent<Text>();
        count = transform.GetChild(1).GetComponent<Text>();
        price = transform.GetChild(2).GetComponent<Text>();

	}

    public void Setup(string itemName, int itemCount, int itemPrice)
    {
        name.text = itemName;
        count.text = itemCount.ToString();
        price.text = itemPrice.ToString();

    }

    
}

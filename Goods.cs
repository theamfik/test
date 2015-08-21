using UnityEngine;
using System.Collections;

public class Goods {

    public string name;
    public int count;
    public int price;

    public Goods(string itemName, int itemCount, int itemPrice)
    {
        name = itemName;
        count = itemCount;
        price = itemPrice;
    }

}

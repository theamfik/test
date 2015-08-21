using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlanetUI : MonoBehaviour
{

    Text itemName;
    Text itemCount;
    Text itemPrice;
    public GameObject marketPanel;
    Planet curPlanet;
    GameObject ItemBar;
    public GameObject ItemBarPrefab;

    void Start()
    {

        int childCount = gameObject.transform.GetChild(2).transform.childCount;

        for (int i = 0; i < curPlanet.items.Count; i++)
        {
            ItemBar = Instantiate(ItemBarPrefab, new Vector3(0, i * -30f, 0), Quaternion.identity) as GameObject;
            RectTransform rect =  ItemBar.transform as RectTransform;
            rect.SetParent(transform.GetChild(2), false);

            UIItemBar bar = ItemBar.GetComponent<UIItemBar>();
            bar.Setup(curPlanet.items[i].name, curPlanet.items[i].count, curPlanet.items[i].price);

        }
    }


    void Update()
    {

    }

    public void OnMarketButton()
    {
        CloseAllPanels();
        marketPanel.SetActive(true);
    }

    void CloseAllPanels()
    {
        marketPanel.SetActive(false);
    }

    public void Setup(Planet planet)
    {
        curPlanet = planet;
        
    }


    
}


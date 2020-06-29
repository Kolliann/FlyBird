using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeWindow : MonoBehaviour
{
    public GameObject m_Item;
    public Transform m_Root;
    public PrestigeController gg;
    private GameObject[] _Coins;

    Text[] text;
    private string[] arr;

    // Start is called before the first frame update
    public void Start()
    {
        _Coins = new GameObject[15];

        gg.LoadLeaderBoard(onError, data);

        //Loop through the collection.
    }

    private void onError()
    {
        throw new NotImplementedException();
    }

    private void data(Hashtable obj)
    {
        string saveValue = "";
        string saveValueOtherUser = "";
        Hashtable currentUser = (Hashtable) obj["current"];
        foreach (DictionaryEntry de in currentUser)
        {
            if (de.Key.ToString() == "count")
            {
                saveValue = (string) de.Value;
            }
            else if (de.Key.ToString() == "name")
            {
                saveValue = de.Value + " " + saveValue;

                text = m_Item.GetComponentsInChildren<Text>();
                text[0].text = saveValue;
                //...and create the individual columns.
                _Coins[0] = Instantiate(m_Item, m_Root);
            }
        }

        Hashtable top = new Hashtable();
        ArrayList arr = (ArrayList) obj["top"];
        for (int i = 0; i < arr.Count; i++)
        {
            top = (Hashtable) arr[i];
            foreach (DictionaryEntry dictionaryEntry in top)
            {
                if ((string) dictionaryEntry.Key == "count")
                {
                    saveValueOtherUser = (string) dictionaryEntry.Value;
                }
                else if ((string) dictionaryEntry.Key == "name")
                {
                    saveValueOtherUser = dictionaryEntry.Value + " " + saveValueOtherUser;

                    text = m_Item.GetComponentsInChildren<Text>();
                    text[0].text = saveValueOtherUser;
                    //...and create the individual columns.
                    _Coins[0] = Instantiate(m_Item, m_Root);
                }
            }
        }

        



    }
}
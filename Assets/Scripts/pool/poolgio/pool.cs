using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{

    GameObject item;
    int tamaño;
    Ipool[] items;
    GameObject[] objects;
    int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (item.GetComponent<Ipool>() == null)
        {
            Debug.LogError("missing Ipool Interface");
            return;

        }
        items = new Ipool[tamaño];
        objects = new GameObject[tamaño];
        for(int i = 0; i < tamaño; i++)
        {
            objects[i] = Instantiate(item, transform.position, Quaternion.identity);
            objects[i].transform.parent = transform;
            items[i] = objects[i].GetComponent<Ipool>();
            items[i].Instantiate();
        }



    }


    public GameObject GetItem(Vector3 position)
    {
        items[index].Begin(position);
        GameObject tmp = objects[index];
        index++;
        if (index >= items.Length) index = 0;
        return tmp;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

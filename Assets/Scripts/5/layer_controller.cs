using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_controller : MonoBehaviour
{

    public GameObject[] toys;
    public int category;

    void Awake()
    {
        shuffle(); // randomize all gameobject in an array
        setting(category); // set first and second gameobject as answer
    }

    private void shuffle()
    {
        for (int i = 0; i < toys.Length; ++i)
        {
            GameObject temp = toys[i];
            int random = Random.Range(i, toys.Length);
            toys[i] = toys[random];
            toys[random] = temp;
        }
    }

    private void setting(int category)
    {
        switch (category)
        {
            case 1:
                toys[0].gameObject.layer = LayerMask.NameToLayer("A");
                toys[1].gameObject.layer = LayerMask.NameToLayer("A");
                break;

            case 2:
                toys[0].gameObject.layer = LayerMask.NameToLayer("B");
                toys[1].gameObject.layer = LayerMask.NameToLayer("B");
                break;

            case 3:
                toys[0].gameObject.layer = LayerMask.NameToLayer("C");
                toys[1].gameObject.layer = LayerMask.NameToLayer("C");
                break;

            case 4:
                toys[0].gameObject.layer = LayerMask.NameToLayer("D");
                toys[1].gameObject.layer = LayerMask.NameToLayer("D");
                break;

        }

        toys[2].gameObject.layer = LayerMask.NameToLayer("11");
        toys[3].gameObject.layer = LayerMask.NameToLayer("22");
        toys[4].gameObject.layer = LayerMask.NameToLayer("33");
    }
}

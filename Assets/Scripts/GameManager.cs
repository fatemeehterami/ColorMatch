using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] images;
    int[] arrayOfNums = {0,1,2,3,4,5,6,7};
    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color setColor(int numInArray){
        switch(numInArray){
            case 0:
                return Color.blue;
            case 1:
                return Color.blue;
            case 2:
                return Color.blue;
            case 3:
                return Color.blue;
            case 4:
                return Color.blue;
            case 5:
                return Color.blue;

        }
    }
}

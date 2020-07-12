using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour
{
    // Created an empty array of game objects
    private GameObject[] carList;
    private int currentCar = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Counted the no. of child of the object where the script is placed
        carList = new GameObject[transform.childCount];

        // Looping through the child items and filling the array correctly
        for(int i=0; i<transform.childCount; ++i)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        // Deactivating each child in the cars, so in starting nothing is visible
        foreach(GameObject gameObj in carList)
        {
            gameObj.SetActive(false);
        }

        // Then activating the first child
        if(carList[0])
        {
            carList[0].SetActive(true);
        }
    }

    public void toggleCars(string direction) 
    {
        carList[currentCar].SetActive(false);
        if(direction == "Right")
        {
            currentCar++;
            if(currentCar > carList.Length - 1) 
            {
                currentCar = 0;
            }
        }
        else if(direction == "Left")
        {
            currentCar--;
            if(currentCar < 0)
            {
                currentCar = carList.Length - 1;
            }
        }

        // Set the current car to be active
        carList[currentCar].SetActive(true);
        gameController.currentSelectedCar = carList[currentCar].name;

        // GameObject cloudSystem = Instantiate(Resources.Load("CloudParticle")) as GameObject;
        // ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
        // cloudPuff.Play();
        // cloudPuff.transform.position = new Vector3(22.76f, 2.5f, -1.5f);
    }
}

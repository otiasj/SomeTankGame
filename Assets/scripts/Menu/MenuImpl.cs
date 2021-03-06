﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuImpl : MonoBehaviour, Menu
{
    public GameObject currentTarget;
    public GameObject spawnPosition;
    public GameObject objectMenu;
    public GameObject[] objectMenuList;
    public GameObject[] objectList;
    public int[] maxNumberOfObject;
    private int[] numberOfObject;
    public string[] titles;
    public Text title;
    public float[] respawnSpeed;

    private int currentPosition = 0;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private float menuSpeed = 2f;
    private float menuPositionXOffset;

    public void Start()
    {
        menuPositionXOffset = objectMenu.transform.localPosition.x;
        

        numberOfObject = new int[maxNumberOfObject.Length];
        for (int i = 0; i < maxNumberOfObject.Length; i++)
        {
            numberOfObject[i] = maxNumberOfObject[i];
        }

        title.text = createTitle(currentPosition);
        title.enabled = false;
    }

    public void Update()
    {
        moveMenu();
    }

    public void enable()
    {
        //Debug.Log("Menu enabled");
        objectMenu.SetActive(true);
        title.enabled = true;
    }

    public void disable()
    {
        //Debug.Log("Menu disabled");
        objectMenu.SetActive(false);
        title.enabled = false;
    }

    public void navigateUp()
    {
        //Debug.Log("Menu up");
    }

    public void navigateDown()
    {
        //Debug.Log("Menu down");
    }

    public void navigateLeft()
    {
        //Debug.Log("Menu left");
        if (!isMovingRight)
        {
            currentPosition -= 1;
            if (currentPosition < 0)
            {
                currentPosition = 0;
            }
            else
            {
                isMovingLeft = false;
                isMovingRight = true;
            }
        }
        title.text = createTitle(currentPosition);
    }

    public void navigateRight()
    {
        //Debug.Log("Menu right");
        if (!isMovingLeft)
        {
            currentPosition += 1;
            if (currentPosition > objectList.Length - 1)
            {
                currentPosition = objectList.Length - 1;
            }
            else
            {
                isMovingLeft = true;
                isMovingRight = false;
            }
        }
        title.text = createTitle(currentPosition);
    }

    public void navigateSelect()
    {
        //Debug.Log("Menu selected " + currentPosition);

        //Spawn a new object instance
        int count = numberOfObject[currentPosition];
        if (count > 0)
        {
            GameObject newObject = Instantiate(objectList[currentPosition], spawnPosition.transform.position, objectMenuList[currentPosition].transform.rotation);
            newObject.SetActive(true);
            newObject.GetComponent<Projectiles>().FireAt(currentTarget);

            numberOfObject[currentPosition] = count - 1;
            title.text = createTitle(currentPosition);

            StartCoroutine(respawnObject(respawnSpeed[currentPosition], currentPosition));
        }
    }

    private void moveMenu()
    {
        if (isMovingLeft)
        {
            objectMenu.transform.Translate(Vector2.left * menuSpeed * Time.deltaTime);
            if (menuReachedNextPosition(objectMenu.transform.localPosition.x))
            {
                isMovingLeft = false;
            }
        }
        else if (isMovingRight)
        {
            objectMenu.transform.Translate(Vector2.right * menuSpeed * Time.deltaTime);
            if (menuReachedNextPosition(objectMenu.transform.localPosition.x))
            {
                isMovingRight = false;
            }
        }
    }

    //Return true if the menuObject as reached the next position in the menu
    private bool menuReachedNextPosition(float xPosition)
    {
        float currentMenuObjectPosition = -(xPosition - menuPositionXOffset);
        float stopAt = currentPosition * menuPositionXOffset;
        //Debug.Log("Menu " + currentMenuObjectPosition + " " + currentPosition + " " + stopAt);
        if (isMovingLeft)
        {
            return (currentMenuObjectPosition >= stopAt);
        }
        else
        {
            return (currentMenuObjectPosition <= stopAt);
        }
    }

    private string createTitle(int currentIndex)
    {
        return titles[currentIndex] + "\nx" + numberOfObject[currentIndex];
    }

    IEnumerator respawnObject(float delay, int position)
    {
        //Debug.Log("Spawn Wait " + delay + " " + position);
        yield return new WaitForSeconds(delay);
        if (numberOfObject[position] < maxNumberOfObject[position])
        {
            //Debug.Log("Spawn update " + numberOfObject[position] + " " + numberOfObject[position]);
            numberOfObject[position] = numberOfObject[position] + 1;
            if (position == currentPosition)
            {
                title.text = createTitle(currentPosition);
            }
        }
        //yield return null;
    }
}

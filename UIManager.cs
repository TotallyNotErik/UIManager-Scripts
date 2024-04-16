using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* File: UIManager.cs
 * Author: Erik Chov
 * Purpose: Default template for screen progression in Unity.
 *          Allows for changing of screens and using the escape button to de-navigate UI
 *          Intended to be used, modified, and added onto for any specific UI needs
 */

public class UIManager : MonoBehaviour
{
    /*==================================================== Variables ====================================================*/
    /* public GameObject[] screens;
     * creates a public array of GameObjects that can be set in the inspector */
    public GameObject[] screens; 
    
    /* public static UIManager instance;
     * creates a static instance of this script, making any other script able to call 
     * functions from this script without the need for an explicit reference */
    public static UIManager instance;

    /* private int previousScreenIndex;
    * integer holding the index of the current screen */
    private int currentScreenIndex = 0;


    /*==================================================== Functions ====================================================*/
    /* private void Awake() {};
     * Takes no arguments and returns nothing.
     * 
     * The Awake function is called before ANY AND ALL Start() functions
     * Sets the static variable, instance, of UIManager to the current script
     */
    private void Awake()
    {
        instance = this;
    }

    /* private void Update() {};
    * Takes no arguments and returns nothing.
    * 
    * The Update function is called every frame.
    */
    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
            Back();

    }

    /* public void ChangeScreen(int screenId) {};
     * Takes an integer and returns nothing
     * 
     * ChangeScreen will disable all screens except the one with the index 
     * matching the input number, then print a success message to the console.
     * 
     * If the input variable is outside the possible index, the function will print 
     * an error and return, the current screen will remain the same. 
     */
    public void ChangeScreen(int screenId)
    {
        if (screenId < 0 ||  screenId > screens.Length)
        {
            Debug.Log("Error! Outside the index for Screens, try something between 0 and " + screens.Length);
            return;
        }

        for(int i = 0; i < screens.Length; i++) 
        {
            screens[i].gameObject.SetActive(i == screenId);
        }
        currentScreenIndex = screenId;
        Debug.Log("Screen number " + screenId + " has been set!");
    }

    /* public void Back() {};
     * 
     * Takes no arguments and returns nothing
     * 
     * Changes the screen to one index back.
     * Allows for certain screen indexes to go back to a specific screen, in the
     * event of non-linear screen progression */
    public void Back()
    {
        /* This comment is left here intentionally, uncomment if you need it.
        if (currentScreenIndex == 1)
        {
            ChangeScreen(0);
        }
        else if (currentScreenIndex == 3)
        {
            ChangeScreen(0);
        }
        else
        */
        ChangeScreen(currentScreenIndex - 1);
    }

}

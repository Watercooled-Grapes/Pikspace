using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputManagerScript : MonoBehaviour
{
    [SerializeField] private InputActionProperty yButton;
    [SerializeField] private InputActionProperty rTrigger;
    [SerializeField] private InputActionProperty aButton;
    [SerializeField] private InputActionProperty xButton;
    [SerializeField] private InputActionProperty bButton;

    [SerializeField] private GameObject photoManager;
    [SerializeField] private GameObject photoBook;
    [SerializeField] private GameObject photoDisplay;
    [SerializeField] private GameObject uiSettings;

    private bool readyToPhotograph = true;
    private bool readyToToggleBook = true;
    private bool bookOpen = false;
    private bool readyToFlipL = true;
    private bool readyToFlipR = true;
    private bool settingsToggle = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (bButton.action.ReadValue<float>() != 0)
        // {
        //     if (settingsToggle)
        //     {
        //         
        //         settingsToggle = false;
        //     }
        //     
        // }
        // else
        // {
        //     settingsToggle = true;
        // }
        
        if (rTrigger.action.ReadValue<float>() != 0)
        {
            if (readyToPhotograph)
            {
                photoManager.GetComponent<PhotoManagerScript>().takePhoto();
                readyToPhotograph = false;
            }
        } else
        {
            readyToPhotograph = true;
        }

        if (yButton.action.ReadValue<float>() != 0)
        {
            if (readyToToggleBook)
            {
                readyToToggleBook = false;
                bookOpen = !bookOpen;
                photoBook.SetActive(bookOpen);
            }
        }
        else
        {
            readyToToggleBook = true;
        }

        if (xButton.action.ReadValue<float>() != 0 && bookOpen)
        {
            if (readyToFlipL)
            {
                photoDisplay.GetComponent<PhotoBookScript>().prevPhoto();
                readyToFlipL = false;
            }
        }
        else
        {
            readyToFlipL = true;
        }

        if (aButton.action.ReadValue<float>() != 0 && bookOpen)
        {
            if (readyToFlipR)
            {
                photoDisplay.GetComponent<PhotoBookScript>().nextPhoto();
                readyToFlipR = false;
            }
        }
        else
        {
            readyToFlipR = true;
        }
    }
}

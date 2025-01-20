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
    [SerializeField] private InputActionProperty lTrigger;

    [SerializeField] private GameObject photoManager;
    [SerializeField] private GameObject photoBook;
    [SerializeField] private GameObject photoDisplay;
    [SerializeField] private GameObject uiSettings;

    private bool readyToPhotograph = true;
    private bool readyToDelete = true;
    private bool readyToToggleBook = true;
    private bool bookOpen = false;
    private bool settingsOpen = false;
    private bool readyToFlipL = true;
    private bool readyToFlipR = true;
    private bool settingsToggle = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bButton.action.ReadValue<float>() != 0)
        {
            if (settingsToggle)
            {
                settingsToggle = false;
                settingsOpen = !settingsOpen;
                uiSettings.SetActive(settingsOpen);
            }
        }
        else
        {
            settingsToggle = true;
        }

        if (rTrigger.action.ReadValue<float>() != 0)
        {
            if (readyToPhotograph && !settingsOpen)
            {
                readyToPhotograph = false;
                photoManager.GetComponent<PhotoManagerScript>().takePhoto();
            }
        }
        else
        {
            readyToPhotograph = true;
        }

        if (lTrigger.action.ReadValue<float>() != 0)
        {
            if (readyToDelete && !settingsOpen)
            {
                readyToDelete = false;
                photoDisplay.GetComponent<PhotoBookScript>().deletePhoto();
            }
        }
        else
        {
            readyToDelete = true;
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
                readyToFlipL = false;
                photoDisplay.GetComponent<PhotoBookScript>().prevPhoto();
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
                readyToFlipR = false;
                photoDisplay.GetComponent<PhotoBookScript>().nextPhoto();
            }
        }
        else
        {
            readyToFlipR = true;
        }
    }
}
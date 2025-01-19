using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputManagerScript : MonoBehaviour
{
    [SerializeField] private InputActionProperty xButton;
    [SerializeField] private InputActionProperty rTrigger;
    [SerializeField] private InputActionProperty leftJoystickL;
    [SerializeField] private InputActionProperty leftJoystickR;

    [SerializeField] private GameObject photoManager;
    [SerializeField] private GameObject photoBook;
    [SerializeField] private GameObject photoDisplay;

    private bool readyToPhotograph = true;
    private bool readyToToggleBook = true;
    private bool bookOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (xButton.action.ReadValue<float>() != 0)
        {
            if (readyToToggleBook)
            {
                photoManager.GetComponent<PhotoManagerScript>().takePhoto();
                readyToToggleBook = false;
                bookOpen = !bookOpen;
                photoBook.SetActive(bookOpen);
            }
        }
        else
        {
            readyToToggleBook = true;
        }

        if (leftJoystickL.action.ReadValue<float>() != 0 && bookOpen)
        {
            photoDisplay.GetComponent<PhotoBookScript>().prevPhoto();
        }

        if (leftJoystickR.action.ReadValue<float>() != 0 && bookOpen)
        {
            photoDisplay.GetComponent<PhotoBookScript>().nextPhoto();
        }
    }
}

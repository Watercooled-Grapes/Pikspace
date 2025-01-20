using UnityEngine;

public class PhotoBookLocationScript : MonoBehaviour
{
    [SerializeField] private Transform playerLocation;
    [SerializeField] private GameObject photoBook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnEnable()
    {
        gameObject.transform.position = playerLocation.transform.position ;
        gameObject.transform.rotation = playerLocation.transform.rotation;
        photoBook.GetComponent<PhotoBookScript>().resetPhoto();
    }
}
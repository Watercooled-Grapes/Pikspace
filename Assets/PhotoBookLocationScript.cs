using UnityEngine;

public class PhotoBookLocationScript : MonoBehaviour
{
    [SerializeField] private Transform playerLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        transform.position = playerLocation.position;
        transform.rotation = playerLocation.rotation;
    }
}

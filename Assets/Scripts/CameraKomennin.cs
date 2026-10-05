using UnityEngine;

public class CameraKomennin : MonoBehaviour
{
    GameObject drooniOlio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      drooniOlio = GameObject.Find("Drooni");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = drooniOlio.transform.position;
        
    }
}

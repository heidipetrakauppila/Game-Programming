using UnityEngine;

public class CameraKomennin : MonoBehaviour
{
    GameObject drooniOlio;

    [SerializeField]
    float kameranEtaisyys = 5f; 

    [SerializeField]
    float kameranKorkeus = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      drooniOlio = GameObject.Find("Drooni");
    }

    // Update is called once per frame
    void Update()
    {
        // Laitetaan pääkameran paikaksi, sama kuin drone
        transform.position = drooniOlio.transform.position;

        // Siirretään kameraa hieman taaksepäin, jotta drone näkyy paremmin
        //transform.position = transform.position-Vector3.forward * 5f;
        transform.position = transform.position - drooniOlio.transform.forward * kameranEtaisyys;

        // Siirretään kameraa ylöspäin nykyisestä positiosta
        transform.position = transform.position + Vector3.up * kameranKorkeus;
        
        // Laitetaan kamera katsomaan droonin positiota kohti
        transform.LookAt(drooniOlio.transform.position);

    }
}

using UnityEngine;
using TMPro;

public class DrooniHUD : MonoBehaviour
{
    TMP_Text drooninPaikkaHUDTeksti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tekstinOmistaja = GameObject.Find("DronenPaikka");
        drooninPaikkaHUDTeksti = tekstinOmistaja.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        drooninPaikkaHUDTeksti.text = "DROONIN PAIKKA: " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z;
    }
}

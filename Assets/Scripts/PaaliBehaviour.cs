using UnityEngine;

public class PaaliBehaviour : MonoBehaviour
{

    public bool ollakkoVaiEikoOlla = true;
    public int kuinkaMontaOmenaaOnPuussa = 10;

    public float desimaaliLuku = 4.5f;
    public string nimi = "testi";
    public Rigidbody fysiikkaOlio;
    public GameObject jakkaratuoli;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      Debug.Log("Tervehdys maailma, olemme Startissa");  
      // Haettiin fysiikkaOlio muuttujaan Rigidbody komponentti Paalo gameobjektista
      fysiikkaOlio = GetComponent<Rigidbody>();
      // Haetaan jakkaratuoli muuttujaan unityn hierarkiasta Jakkara niminen GameObject käyttäen 
      // GameObject luokassa olevaa staattista Find metodia.    
      jakkaratuoli = GameObject.Find("Jakkara");

      jakkaratuoli.transform.position = jakkaratuoli.transform.position + Vector3.left*0.01f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("Olemme Update Metodissa");
        // Annetaan maanvetovoiman (9.81) kumoava vektorivoima paali gameObjektille
        // Vector3.up ( 0, 1, 0 )' 9.81 ---> 8 0, 9.81, 0 )
        fysiikkaOlio.AddForce( Vector3.up*9.81f + Vector3.left*0.1f + Vector3.down*0.1f );
    }
}

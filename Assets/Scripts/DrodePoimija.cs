using UnityEngine;

public class DrodePoimija : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision osumaTieto)
    {
        Debug.Log("Osuttiin dronella seuraavaan peliobjektiin" + osumaTieto.gameObject.name);
            
        //JOS osuttu esine on nimeltään PoimittavaPata tai Kori, niin poimitaan esine
        if (osumaTieto.gameObject.name.StartsWith("PoimittavaPata") || 
            osumaTieto.gameObject.name.StartsWith("Kori") || 
            osumaTieto.gameObject.name.StartsWith("PoimittavaEsine")) //tägi
            
            {
            Debug.Log("Poimitaan pata pois pelistä"); 
            // Poimitaan elementti pois pelistä, eli piilotetaan se
            osumaTieto.gameObject.SetActive(false);
            }
    }
}

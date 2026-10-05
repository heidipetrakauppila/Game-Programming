using UnityEngine;
using UnityEngine.InputSystem;

public class DrodePoimija : MonoBehaviour
{
    
    InputAction rNappiPaienettu;
    GameObject poimittavaEsine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rNappiPaienettu = InputSystem.actions.FindAction("Poiminta"); 
       poimittavaEsine = GameObject.Find("MustaherukkaJuomaa"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (rNappiPaienettu.IsPressed())
        {
            Debug.Log("R-poiminta nappi painettu");
            float etaisyysPoimittavaanEsineeseen = Vector3.Distance(transform.position, poimittavaEsine.transform.position);
            Debug.Log("Etäisyys poimittavaan esineeseen: " + etaisyysPoimittavaanEsineeseen);
            //JOS etäisyys poimittavaan esineeseen on pienempi kuin 1.4f
            if (etaisyysPoimittavaanEsineeseen < 1.4f)
            {
                Debug.Log("Esine on poimittavissa. Poimittiin esine: " + poimittavaEsine.name );
                poimittavaEsine.SetActive(false);
            }
        }
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

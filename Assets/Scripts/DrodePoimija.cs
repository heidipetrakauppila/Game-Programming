using UnityEngine;
using UnityEngine.InputSystem;

public class DrodePoimija : MonoBehaviour
{
    
    InputAction rNappiPainettu;
    InputAction tNappiPainettu;

    GameObject poimittavaEsine;

    [SerializeField]
    GameObject[] poimittavatEsineet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rNappiPainettu = InputSystem.actions.FindAction("Poiminta"); 
       tNappiPainettu = InputSystem.actions.FindAction("PoimiUseita");
       poimittavaEsine = GameObject.Find("MustaherukkaJuomaa"); 
       poimittavatEsineet = GameObject.FindGameObjectsWithTag("PoimittavaEsine");
    }

    // Update is called once per frame
    void Update()
    {
        // R-napilla haetaan yksi poimittava esine, joka kentässä on.
        if ( rNappiPainettu.IsPressed() )
        {
            Debug.Log("R-poiminta nappi painettu");
            float etaisyysPoimittavaanEsineeseen = Vector3.Distance(transform.position, poimittavaEsine.transform.position);
            Debug.Log("Etäisyys poimittavaan esineeseen " + etaisyysPoimittavaanEsineeseen);
            //JOS etäisyys poimittavaan esineeseen on pienempi kuin 1.4f
            if( etaisyysPoimittavaanEsineeseen < 1.4f )
            {
                Debug.Log("Esine on poimittavissa. Poimittiin esine: " + poimittavaEsine.name );
                poimittavaEsine.SetActive(false);
            }
        }

        // T-napilla haetaan kentästä kaikki poimittavat, joita siellä on. 
        // Jos esineet, tai esine on lähempänä kuin 1.4f, niin poimitaan se pois pelistä
        if ( tNappiPainettu.IsPressed() )
        {
            Debug.Log("T-poiminta nappi painettu" + poimittavatEsineet.Length );
            for ( int index = 0; index < poimittavatEsineet.Length; index++ )
            {
                GameObject esine = poimittavatEsineet[index];
                Debug.Log("Käsitellään esinettä: " + esine.name + " käsiteltävä indeksi: " + index);
                
                float etais = Vector3.Distance(transform.position, esine.transform.position);
                Debug.Log("Etäisyys esineeseen: " + etais);
                
                //JOS etäisyys poimittavaan esineeseen on pienempi kuin 1.4f
                if ( etais < 1.4f )
                {
                    Debug.Log("Esine on poimittavissa. Poimittiin esine: " + esine.name);
                    esine.SetActive(false);
                }
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

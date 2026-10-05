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
        {
            Debug.Log("Osuttiin dronella seuraavaan peliobjektiin" + osumaTieto.gameObject.name);
            // Poimitaan elementti pois pelistä, eli piilotetaan se
            osumaTieto.gameObject.SetActive(false);
        }
    }
}

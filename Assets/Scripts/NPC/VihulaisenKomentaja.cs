using UnityEngine;

public enum VihulaisenTila
{
    Idle = 0,
    EtsiPelaaja,
    Hyokkaa,
    Peitottu
}

public class VihulaisenKomentaja : MonoBehaviour
{

    [SerializeField]
    VihulaisenTila m_vihulaisenTila;

    [SerializeField]
    GameObject m_pelaajaTarget;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // alustetaan muuttujat
        m_vihulaisenTila = VihulaisenTila.Idle;
        m_pelaajaTarget = GameObject.Find("Drooni");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_vihulaisenTila == VihulaisenTila.Idle)
        {
            // käsitellään Idle tila
            float etaisyys = Vector3.Distance(transform.position, m_pelaajaTarget.transform.position);
            
            if (etaisyys < 8f)
            {
                m_vihulaisenTila = VihulaisenTila.EtsiPelaaja;
            }
        }
        else if (m_vihulaisenTila == VihulaisenTila.EtsiPelaaja)
        {
            // käsitellään EtsiPelaaja tila
            transform.LookAt(m_pelaajaTarget.transform);

            //tarkastetaan tilasiirtymän tarve
            float etaisyys = Vector3.Distance(transform.position, m_pelaajaTarget.transform.position);
            if (etaisyys < 3f)
            {
                m_vihulaisenTila = VihulaisenTila.Hyokkaa;
            }
            if (etaisyys > 11f)
            {
                m_vihulaisenTila = VihulaisenTila.Idle;
            }
        }
        else if (m_vihulaisenTila == VihulaisenTila.Hyokkaa)
        {
            // käsitellään Hyokkaa tila
        }
        else 
        {
            // käsitellään Peitottu tila, else haara toimii default tilana.
        }
    
    }
}

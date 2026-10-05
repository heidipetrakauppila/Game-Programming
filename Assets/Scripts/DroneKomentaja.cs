using UnityEngine;
using UnityEngine.InputSystem;

public class DroneKomentaja : MonoBehaviour
{

    InputAction liikeInteraktion;
    InputAction hyppyInteraktion;

    Vector2 wasdLiike;
    Rigidbody droneFysiikka;

    [SerializeField]
    float drooninNopeus = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        liikeInteraktion = InputSystem.actions.FindAction("Move");
        hyppyInteraktion = InputSystem.actions.FindAction("Jump");
        droneFysiikka = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2, ensimäinen ja a ja d napit. -1->s, 1->d 
        // Toinen ja w ja s napit. -1->s, 1->w. -1->s, 1->w
        wasdLiike = liikeInteraktion.ReadValue<Vector2>();
        Debug.Log("Wasd liikkeen lukeminen: " + wasdLiike);
    }

    void FixedUpdate()
    {
        // ( x, y, z ) -> 0, 0, 1
        // ( x ,y ) -> 0, 1
        Vector3 voimaVektoriDronelle = new Vector3(wasdLiike.x*drooninNopeus, 0f, wasdLiike.y*drooninNopeus);
        droneFysiikka.AddRelativeForce( voimaVektoriDronelle);
    }
}
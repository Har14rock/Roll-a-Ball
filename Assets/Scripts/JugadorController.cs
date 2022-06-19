using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JugadorController : MonoBehaviour
{
  private Rigidbody rb; 

    //Inicializo el contador de coleccionables recogidos
    private int contador; 
     AudioSource reproductorSonidos;
    //Inicializo variables para los textos
    public Text TextoContador, TextoGanar; 

    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    public float velocidad; 

    public AudioClip sonidoCoin;
    public AudioClip sonidoWin;

    // Use this for initialization 
    void Start() { 
        //Capturo esa variable al iniciar el juego
         rb = GetComponent<Rigidbody>();
          //Inicio el contador a 0 
          contador = 0; 
          //Actualizo el texto del contador por pimera vez 
          setTextoContador(); 
          //Inicio el texto de ganar a vacío
           TextoGanar.text = ""; 
           reproductorSonidos = GetComponent<AudioSource>();
           } 
           // Para que se sincronice con los frames de física del motor
            void FixedUpdate() { 
                //Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado
                
                 float movimientoH = Input.GetAxis("Horizontal"); float movimientoV = Input.GetAxis("Vertical");
                 
                 
                  Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV); 
                  
                  
                   rb.AddForce(movimiento * velocidad); } 
              
                   void OnTriggerEnter(Collider other) {

                        if (other.gameObject.CompareTag("Coleccionable")) {
                             //Desactivo el objeto 
                             other.gameObject.SetActive(false); 
                             //Incremento el contador en uno (también se peude hacer como contador++)
                              contador = contador + 1; 
                              reproductorSonidos.PlayOneShot(sonidoCoin);
                              //Actualizo elt exto del contador 
                              setTextoContador(); 

                              } 
                        } 
                       
                        void setTextoContador(){

                             TextoContador.text = "Contador: " + contador.ToString(); 

                             if (contador >= 12) { 

                              TextoGanar.text = "¡Ganaste!";
                              reproductorSonidos.PlayOneShot(sonidoWin);

                                 } 
                                 
                                 
                    }


}

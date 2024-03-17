using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player_;

    public AudioClip[] sonidos;

    public GameObject getPlayer() { return player_; }

    [SerializeField]
    private TextManager textManager_;
    public TextManager getTextManager() { return textManager_; }

    [SerializeField]
    private FlashComponent flashCanvas_;
    public void initFlash() { flashCanvas_.startFlash(); }

    private static GameManager _instance;

    private GameObject objectToDestroy;


    // Instancia publica de GameManager
    public static GameManager Instance
    {
        get
        {
            // Si la instancia no existe, la creamos
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // Si no hay una instancia en la escena, lanzamos un error
                if (_instance == null)
                {
                    Debug.LogError("GameManager no encontrado en la escena.");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Si hay una instancia que ya existe y no es esta, la destruimos
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Establecemos esta instancia como la única
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public enum Habitaciones {
        h0 = 0, // no sirve para nada, solo es para que cuadren los indices y las ids de los dialogos
        hab_1 = 1,
        hab_2 = 2,
        hab_3 = 3,
        hab_4 = 4,
        hab_5 = 5,
        hab_6 = 6,
        hab_7 = 7,
        hab_8 = 8
    }

    public Habitaciones currHab;

    // Start is called before the first frame update
    void Start()
    {
        currHab = Habitaciones.hab_1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getHabitacion() { return ((int)currHab); }
    /// <summary>
    /// Avanza de habitacion mientras se pueda
    /// </summary>
    public void nextHabitacion()
    {
        currHab++;
    }
    public bool isWriting()
    {
        return textManager_.IsWritting();
    }
    public bool hasFinished()
    {
        return textManager_.hasFinished();
    }

    public void Playsound(int x)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = sonidos[x];
        audio.Play();
    }

    public void DestroyInOneSecond(GameObject gameObj)
    {
        objectToDestroy = gameObj;
        Invoke("destroyGameObject", 0.8f);
    }

    public void destroyGameObject()
    {
        if (objectToDestroy != null)
        {
            // habitacionAnterior.parent 
            Debug.Log("Se destrruye habitacion" + gameObject);
            Destroy(gameObject);
        }
    }
}

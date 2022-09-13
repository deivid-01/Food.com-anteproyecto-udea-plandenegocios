using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    #region 1 Problema
    public GameObject slide0;
    public Transform[] pivotes;
    public GameObject people;
    public int elementoActual;
    [Range(.1f, 10f)]
    public int speed;

    #endregion
    #region 2 Solution
    public GameObject arrow;
    public GameObject phone;
    #endregion
    #region 3 Conexion
    public GameObject conextions;
    #endregion
    
   
    private void Awake()
    {
        #region 1 Problema
        if (people!=null)
            people.SetActive(false);
        #endregion
    }
    void Start()
    {
        elementoActual = 0;
        #region 2 Solution
        if(arrow!=null)
            arrow.SetActive(false);
        if(phone!=null)
            phone.SetActive(false);
        #endregion
        #region 3 Conexion
        if (conextions != null)
        {
            conextions.SetActive(false);
        }
        #endregion
        elementoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("1 Problema") || SceneManager.GetActiveScene().name.Equals("4 Canvas"))
        {
          
            transform.position = Vector3.Lerp(transform.position, pivotes[elementoActual].position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, pivotes[elementoActual].rotation, speed * Time.deltaTime * 0.9f);

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (slide0 != null)
                {
                    if (slide0.activeInHierarchy)
                    {
                        slide0.SetActive(false);
                        return;
                    }
                }
                if (elementoActual == 1)
                {
                    if (SceneManager.GetActiveScene().name.Equals("1 Problema"))
                        SceneManager.LoadScene("2 Solucion");
                }
                if (people != null)
                {
                    if (people.activeInHierarchy)
                        people.SetActive(false);
                    else
                        people.SetActive(true);
                }
                elementoActual = (elementoActual + 1) % pivotes.Length;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (SceneManager.GetActiveScene().name.Equals("4 Canvas"))
                {
                    elementoActual = elementoActual - 1;
                    if (elementoActual < 0)
                    {
                        elementoActual = pivotes.Length - 1;
                    }
                }
            }


        }

        else if (SceneManager.GetActiveScene().name.Equals("2 Solucion"))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {


                if (!arrow.activeInHierarchy)
                {
                    arrow.SetActive(true);
                }
                else
                {
                    if (!phone.activeInHierarchy)
                    {
                        phone.SetActive(true);
                    }
                    else
                    {
                        SceneManager.LoadScene("3 Conexion");
                    }

                }




            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                SceneManager.LoadScene("1 Problema");
            }
        }

        else if (SceneManager.GetActiveScene().name.Equals("3 Conexion"))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!conextions.activeInHierarchy)
                {
                    conextions.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene("4 Canvas");
                }
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (conextions.activeInHierarchy)
                {
                    conextions.SetActive(false);
                }
                else
                {
                    SceneManager.LoadScene("2 Solucion");
                }
            }

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

    
}
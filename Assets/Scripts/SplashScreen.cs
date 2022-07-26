using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public Transform loadingBar;

    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}

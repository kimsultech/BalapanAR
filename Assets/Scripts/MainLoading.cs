using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLoading : MonoBehaviour
{
    public Transform loadingBar;
    public GameObject loadingPanel;

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
            loadingPanel.SetActive(false);
        }

        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}

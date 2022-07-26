using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrackableList : MonoBehaviour {

    public GameObject btnStart_obj;
    public Button mBtnStart;
    private Button btnStart;

    public Animator mAnimPolice, mAnimMerah, mAnimBus, mAnimKuning, mAnimTaxi;
    private Animator animPolice, animMerah, animBus, animKuning, animTaxi;

    public GameObject mLightPolice, mLightMerah, mLightBus, mLightKuning, mLightTaxi;


    // Start is called before the first frame update
    void Start() {
        btnStart = mBtnStart.GetComponent<Button>();

        btnStart_obj.SetActive(false);

        animPolice = mAnimPolice.GetComponent<Animator>();
		animPolice.Play("police_stay");

        animMerah = mAnimMerah.GetComponent<Animator>();
        animMerah.Play("merah_stay");

        animBus = mAnimBus.GetComponent<Animator>();
        animBus.Play("bus_stay");

        animKuning = mAnimKuning.GetComponent<Animator>();
        animKuning.Play("kuning_stay");

        animTaxi = mAnimTaxi.GetComponent<Animator>();
        animTaxi.Play("taxi_stay");

        mLightPolice.SetActive(false);
        mLightMerah.SetActive(false);
        mLightBus.SetActive(false);
        mLightKuning.SetActive(false);
        mLightTaxi.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in activeTrackables) {
            if (activeTrackables.Count() >= 2) {
                btnStart_obj.SetActive(true);
                btnStart.onClick.AddListener(delegate { Balapan(tb.TrackableName); });
            } else {
                btnStart_obj.SetActive(false);
                animPolice.Play("police_stay");
                animMerah.Play("merah_stay");
                animBus.Play("bus_stay");
                animKuning.Play("kuning_stay");
                animTaxi.Play("taxi_stay");

                mLightPolice.SetActive(false);
                mLightMerah.SetActive(false);
                mLightBus.SetActive(false);
                mLightKuning.SetActive(false);
                mLightTaxi.SetActive(false);
            }
        }
    }

    void Balapan(string nama) {
		animPolice.Play("police_drive");
        animMerah.Play("merah_drive");
        animBus.Play("bus_drive");
        animKuning.Play("kuning_drive");
        animTaxi.Play("taxi_drive");

        if (animPolice.GetCurrentAnimatorStateInfo(0).IsName("police_drive")) {
            animPolice.Play("police_stay");
        }
        if (animMerah.GetCurrentAnimatorStateInfo(0).IsName("merah_drive")) {
            animMerah.Play("merah_stay");
        }
        if (animBus.GetCurrentAnimatorStateInfo(0).IsName("bus_drive")) {
            animBus.Play("bus_stay");
        }
        if (animKuning.GetCurrentAnimatorStateInfo(0).IsName("kuning_drive")) {
            animKuning.Play("kuning_stay");
        }
        if (animTaxi.GetCurrentAnimatorStateInfo(0).IsName("taxi_drive")) {
            animTaxi.Play("taxi_stay");
        }

        mLightPolice.SetActive(true);
        mLightMerah.SetActive(true);
        mLightBus.SetActive(true);
        mLightKuning.SetActive(true);
        mLightTaxi.SetActive(true);
	}

    public void backToMenu() {
        SceneManager.LoadScene("Menu");
    }
}

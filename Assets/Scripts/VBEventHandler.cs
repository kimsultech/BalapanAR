using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;


public class VBEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vb_police_1, vb_merah_1, vb_bus_1, vb_kuning_1, vb_taxi_1;
    public GameObject Police_car, Merah_car, Bus_car, Kuning_car, Taxi_car;

	Vector3 PoliceDefaultScale, MerahDefaultScale, BusDefaultScale, KuningDefaultScale, TaxiDefaultScale;


    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; i++) {
			vbs [i].RegisterEventHandler (this);
		}
		//Cari Object 
		vb_police_1 = GameObject.Find("vb_police_1");
		vb_merah_1 = GameObject.Find("vb_merah_1");
		vb_bus_1 = GameObject.Find("vb_bus_1");
		vb_kuning_1 = GameObject.Find("vb_kuning_1");
		vb_taxi_1 = GameObject.Find("vb_taxi_1");
		
		PoliceDefaultScale = Police_car.gameObject.transform.localScale;
		MerahDefaultScale = Merah_car.gameObject.transform.localScale;
		BusDefaultScale = Bus_car.gameObject.transform.localScale;
		KuningDefaultScale = Kuning_car.gameObject.transform.localScale;
		TaxiDefaultScale = Taxi_car.gameObject.transform.localScale;

    }

    //Buten di tekan/tutupi
	public void OnButtonPressed(VirtualButtonBehaviour vb) {
		// Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in activeTrackables) {
            if (activeTrackables.Count() >= 2) {
                // eweuh
            } else {
                switch (vb.VirtualButtonName) {
					case "vb_police_1":
						Police_car.gameObject.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
						break;
					case "vb_merah_1":
						Merah_car.gameObject.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
						break;
					case "vb_bus_1":
						Bus_car.gameObject.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
						break;
					case "vb_kuning_1":
						Kuning_car.gameObject.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
						break;
					case "vb_taxi_1":
						Taxi_car.gameObject.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
						break;
				}
            }
        }
	}

	//Button di Lepas
	public void OnButtonReleased(VirtualButtonBehaviour vb) {
		switch (vb.VirtualButtonName) {
		case "vb_police_1":
			Police_car.gameObject.transform.localScale = PoliceDefaultScale;
			break;
		case "vb_merah_1":
			Merah_car.gameObject.transform.localScale = MerahDefaultScale;
			break;
		case "vb_bus_1":
			Bus_car.gameObject.transform.localScale = BusDefaultScale;
			break;
		case "vb_kuning_1":
			Kuning_car.gameObject.transform.localScale = KuningDefaultScale;
			break;
		case "vb_taxi_1":
			Taxi_car.gameObject.transform.localScale = TaxiDefaultScale;
			break;
		}
	}

    // Update is called once per frame
    void Update() {
        
    }
}

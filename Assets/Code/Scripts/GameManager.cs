using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int shiftPhase = 0;

    public SE.PlayerInput player;
    //public Camera mainCamera;

    //[SerializeField] private SE.PhaseShiftPlayer _phaseShiftPlayer;
    //[SerializeField] private SE.PhaseShiftBullet _phaseShiftBullet;
    //[SerializeField] private SE.PhaseShiftCamera _phaseShiftCamera;
    public SE.Bullet bullet;
    public Camera playerCamera;

    public static GameManager Instance {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        //_phaseShiftPlayer = GetComponent<SE.PhaseShiftPlayer>();
        //_phaseShiftBullet = GetComponent<SE.PhaseShiftBullet>();
        //_phaseShiftCamera = GetComponent<SE.PhaseShiftCamera>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShiftChange();
    }

    public void UpdatePhase()
    {
        if (shiftPhase == 0)
        {
            Debug.Log("PhaseShift: " + shiftPhase + " light");
            shiftPhase = 1;
        }
        else
        {
            Debug.Log("PhaseShift: " + shiftPhase + " dark");
            shiftPhase = 0;
        }
    }

    public void ShiftChange()
    {
        SE.PhaseShiftCamera.Instance.CameraShiftChange();
        //SE.PhaseShiftBullet.Instance.bulletTarget.color = SE.PhaseShiftBullet.Instance.lightTargetColor;

        /*
        if (shiftPhase == 0)
        {
            Debug.Log("PhaseShift: " + shiftPhase + " light");

        }
        else if (shiftPhase == 1)
        {
            Debug.Log("PhaseShift: " + shiftPhase + " dark");

        }
        */
        
    }

}

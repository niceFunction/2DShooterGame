using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int shiftPhase = 0;

    public SE.PlayerInput player;
    public Camera mainCamera;

    [SerializeField] private SE.PhaseShiftPlayer _phaseShiftPlayer;
    //[SerializeField] private SE.PhaseShiftBullet _phaseShiftBullet;
    //[SerializeField] private SE.PhaseShiftCamera _phaseShiftCamera;

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

    public void ShiftChange()
    {
        //GameManager.Instance.ShiftChange();
        SE.PhaseShiftPlayer playerColor = GetComponent<SE.PhaseShiftPlayer>();
        if (shiftPhase == 0)
        {
            Debug.Log("PhaseShift: " + shiftPhase + " light");
            

            playerColor.GetComponentInChildren<SpriteRenderer>().color = SE.PhaseShiftPlayer.Instance.lightTargetColor;
            //SE.PhaseShiftPlayer.Instance.lightTargetColor;
            //mainCamera.backgroundColor = SE.PhaseShiftCamera.Instance.lightTargetColor;
            //_phaseShiftCamera.targetCamera.backgroundColor = SE.PhaseShiftCamera.Instance.lightTargetColor;
        }
        else if (shiftPhase == 1)
        {
            Debug.Log("PhaseShift: " + shiftPhase + " dark");
            playerColor.GetComponentInChildren<SpriteRenderer>().color = SE.PhaseShiftPlayer.Instance.darkTargetColor;
            //_phaseShiftCamera.targetCamera.backgroundColor = SE.PhaseShiftCamera.Instance.darkTargetColor;
            //mainCamera.backgroundColor = SE.PhaseShiftCamera.Instance.darkTargetColor;
        }
        
    }

}

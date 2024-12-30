using UnityEngine;

public class CursorDetection : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; // Reference to the main camera
    public LayerMask layerToIgnore; // Layers to ignore for the raycast

    public ArtData _CurrentArtData;

    public UIPanelArt _UIPanelArt;

    public UIManagerMBM _UIManager;
    public SpawnManager _SpawnManager;

    public bool IsPanelEnabled;

    private void Start()
    {
        // Ensure the main camera is assigned
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera is not assigned!");
            return;
        }

        // Get a ray from the center of the camera's viewport
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        // Perform a raycast ignoring specific layers
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~layerToIgnore))
        {
            // Log the tag of the 3D object hit by the ray

            //Debug.Log("3D Object at Camera Center: " + hit.collider.gameObject.name + " with Tag: " + hit.collider.gameObject.tag);

            if (hit.collider.gameObject.GetComponent<ArtData>() != null && !IsPanelEnabled)
            {
                _CurrentArtData = hit.collider.gameObject.GetComponent<ArtData>();
                _UIManager.SetArtDetail(_CurrentArtData);
                _UIManager._InfoButton.SetActive(true);
            }
            else if (hit.collider.gameObject.GetComponent<UIPanelArt>() != null)
            {
                _UIPanelArt = hit.collider.gameObject.GetComponent<UIPanelArt>();
                _UIManager._InfoButton.SetActive(true);

                if (hit.collider.gameObject.GetComponent<Gingko>())
                {
                    hit.collider.gameObject.GetComponent<Gingko>().IsLearnedGingko = true;
                }
                //_UIManager._ChangeCamBttn.SetActive(true);
            }
            else
            {
                _CurrentArtData = null;
                _UIPanelArt = null;
                //_UIManager._ChangeCamBttn.SetActive(false);
                _UIManager._InfoButton.SetActive(false);
            }


        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (/*(_CurrentArtData != null || _UIPanelArt!=null) && */!IsPanelEnabled)
            {
               EnableInfoPanel();
            }
            else
            {
               DisableInfoPanel();
            }
        }
    }

    public void EnableInfoPanel()
    {
        if (_CurrentArtData != null)
        {
            _UIManager.InfoTapped();
            IsPanelEnabled = true;
            _SpawnManager.InfoTapped(false);
        }
        else if (_UIPanelArt != null)
        {
            _UIPanelArt._PanelToEnable.SetActive(true);
            IsPanelEnabled = true;
            _SpawnManager.InfoTapped(false);
        }

    }
    public void DisableInfoPanel()
    {
        _UIManager.ClosePanel();
        if(_UIPanelArt!=null)
        _UIPanelArt._PanelToEnable.SetActive(false);
        _SpawnManager.InfoTapped(true);
        IsPanelEnabled = false;
    }



}


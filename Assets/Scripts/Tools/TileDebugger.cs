using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDebugger : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Grid gird;

    [SerializeField]
    private Tile debugTile;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawTile();
        }
    }


    void DrawTile()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        mouseWorldPos.z = 0;



        Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);

        Debug.Log(clickPos);

        tilemap.SetTile(clickPos, debugTile);
        //tilemap.SetTileFlags(new Vector3Int(clickPos.x, clickPos.y, 0), TileFlags.None);
        //tilemap.SetColor(new Vector3Int(clickPos.x, clickPos.y, 0), Color.black);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine.Tilemaps;

public class Karga_1 : MonoBehaviour
{
    private Grid<SbyteGridObject> grid;
    private int2[] path;
    private int pathIndex = 0;
    private float cellSize = 1f;
    private int2 gridSize = new int2(50, 50);
    private Pathfinding pathfinding;
    public float speed = 4;
    public int stunCounter=0;
    NativeArray<PathNode> pathNodeArray;

    private Rigidbody2D rb;
    Transform target;

    public float health = 5f;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public float chance = 25;
    public GameObject companionLink;
    float random;

    void OnTriggerEnter(Collider other){
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAa");
        if (other.tag == "Companion"){
            TakeDamege(2);
        }
    }

    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        TileTest tileTest = FindObjectOfType<TileTest>();
        BoundsInt bounds = tileTest.GetComponent<TileTest>().GetBounds();
        TileBase[] tileBase = tileTest.GetTileBase();

        this.grid = new Grid<SbyteGridObject>(gridSize.x, gridSize.y, cellSize, Vector3.zero, (Grid<SbyteGridObject> g, int x, int y) => new SbyteGridObject(g, x, y));
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                SbyteGridObject costGridObject = grid.GetGridObject(x, y);
                costGridObject.value = 0;
                grid.SetGridObject(x, y, costGridObject);
            }
        }

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = tileBase[x + y * bounds.size.x];
                if (tile != null)
                {
                    SbyteGridObject costGridObject = grid.GetGridObject(x, y);
                    costGridObject.value = -1;
                    grid.SetGridObject(x, y, costGridObject);
                }
            }
        }
        pathfinding = new Pathfinding(new int2(gridSize.x, gridSize.y));

    }

    void Update()
    {
        if (stunCounter==0){
            if (target.position.x >= 10 && target.position.x <= 21 && target.position.y >= 3 && target.position.y <= 9)
            {

                grid.GetXY(transform.position, out int xStart, out int yStart);
                grid.GetXY(target.position, out int x, out int y);
                path = pathfinding.FindPath(new int2(xStart, yStart), new int2(x, y), grid);
                pathIndex = 1;
            }

            if (path == null || path.Length == 0) return;
            Vector2 target_path = new Vector2(path[pathIndex].x * cellSize + cellSize / 2, path[pathIndex].y * cellSize + cellSize / 2);
            float distance = Vector2.Distance(transform.position, target_path);
            Vector2 direction = target_path - (Vector2)transform.position;

            transform.position = Vector2.MoveTowards(transform.position, target_path, speed * Time.deltaTime);

            if (pathIndex < path.Length - 1 && (distance < 0.1f))
            {
                pathIndex++;
            }

            if (health <= 0)
            {
                Destroy(gameObject);

                random = UnityEngine.Random.Range(0, 100);
                if (random <= chance)
                {
                    if (random <= 6)
                    {
                        GameObject Item = Instantiate(item1, transform.position, Quaternion.identity);
                    }

                    if (random >= 7 && random <= 12)
                    {
                        GameObject Item = Instantiate(item2, transform.position, Quaternion.identity);
                    }

                    if (random >= 13 && random <= 18)
                    {
                        GameObject Item = Instantiate(item3, transform.position, Quaternion.identity);
                    }

                    if (random >= 19 && random <= 25)
                    {
                        GameObject Item = Instantiate(item4, transform.position, Quaternion.identity);
                    }
                }
            }
        } else {
            stunCounter -= 1;
        }
    }

    public void Stun(int ticks){
        if ((Vector2.Distance(transform.position, companionLink.transform.position)<= 1.5f) && (stunCounter==0)){
            stunCounter=ticks;
            TakeDamege(2);
        }
    }

    public void TakeDamege(int damage)
    {
        health -= damage;
    }
}


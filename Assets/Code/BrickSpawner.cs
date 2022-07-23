using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BrickSpawner : MonoBehaviour
{
    private const int maxBricks = 10;
    private const float spawnCooldown = 2f;

    [SerializeField] private GameObject _brickPrefab;

    private Transform _spawner;
    private Collider _collider;
    private List<GameObject> _bricks;
    private float _spawnHeight;
    private float _timer;
    public Animator anim;
    protected int animState;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _bricks = new List<GameObject>(maxBricks);
        _spawner = GetComponent<Transform>();
        _spawnHeight = _spawner.position.y + (_spawner.localScale.y / 8);

        SpawnBricks(maxBricks);
        Debug.Log("gameplay_start_hight");

    }
    public Camera Cam;
      private void Raycast()
    {

    }
    private void Update()
    {
        CheckBricks();
        //StartCoroutine(ReSpawBrick1());
        if (Time.time > _timer && _bricks.Count < maxBricks / 2)
        {
            _timer = Time.time + spawnCooldown;
            SpawnBricks(3);
        }
    }

    private void CheckBricks()
    {
        for (int i = 0; i < _bricks.Count; i++)
        {
            if (_bricks[i].transform.position.y != _spawnHeight)
            {
                _bricks.Remove(_bricks[i]);
                i--;
            }
        }
    }
    //IEnumerator ReSpawBrick1()
    //{
    //    yield return new WaitForSeconds(2);
    //    if (_bricks.Count < maxBricks / 2)
    //    {
    //        SpawnBricks(3);
    //    }
    //    StartCoroutine(ReSpawBrick1());
    //}
    private void SpawnBricks(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 startPos = Extensions.RandomPointInCollider(_collider);
            startPos.y = _spawnHeight;
            _bricks.Add(Instantiate(_brickPrefab, startPos, Quaternion.identity));
        }
    }

    
}

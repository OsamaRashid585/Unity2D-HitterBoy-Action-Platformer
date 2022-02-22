using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _bigBallPrefab;
    [SerializeField] private GameObject[] _pickUpPrefabs;
    private Vector3 _ballPos;

    private void Start()
    {
        InvokeRepeating("BallSpwaner", 3, Random.Range(7, 15));
        InvokeRepeating("PickupSpwaner", 15, Random.Range(10, 20));
    }

    private void BallSpwaner()
    {
        if(GameManager.Instance.IsgameOver != true)
        {
            _ballPos = new Vector3(Random.Range(-25, 26), 11, 0);
            Instantiate(_bigBallPrefab, _ballPos, Quaternion.identity);
            GameManager.Instance.Level++;
        }
    }
    private void PickupSpwaner()
    {
        if(GameManager.Instance.IsgameOver != true)
        {
            _ballPos = new Vector3(Random.Range(-25, 26), 11, 0);
            Instantiate(_pickUpPrefabs[Random.Range(0, 2)], _ballPos, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class PathFollower : MonoBehaviour
{
    private float t;
    private Transform _transform;
    [SerializeField] private Path path;

    void Start()
    {
        t = 0;
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        t = (t + Time.deltaTime) % 1;
        _transform.position = path.GetPoint(t);
    }
}
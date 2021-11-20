using UnityEngine;

public class PathFollower : MonoBehaviour
{
    private float t;
    [SerializeField] private Path path;

    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t = (t + Time.deltaTime) % 1;
        transform.position = path.transform.TransformPoint(path.GetPoint(t));
    }
}
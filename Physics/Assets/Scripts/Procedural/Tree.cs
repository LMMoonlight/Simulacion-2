using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]int totalLevels = 2;
    int currentLevel = 0;
    [SerializeField]GameObject branchPrefab;
    Queue<GameObject> frontier = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject root = Instantiate(branchPrefab, transform);
        ++currentLevel;
        frontier.Enqueue(root);
        Queue<string> queue = new Queue<string>();

        CreateBranch(root, 45f);
        CreateBranch(root, -45f);

        GenerateTree();
    }

    void GenerateTree()
    {
        if (currentLevel >= totalLevels) return;
        ++currentLevel;

        List<GameObject> createdBranches = new List<GameObject>();
        while(frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            var leftBranch = CreateBranch(branch, -45);
            var rightBranch = CreateBranch(branch, 45);

            leftBranch.name = "Left Branch";
            rightBranch.name = "Right Branch";
            createdBranches.Add(leftBranch);
            createdBranches.Add(rightBranch);
        }

        foreach (var branch in createdBranches)
        {
            frontier.Enqueue(branch);
        }
        GenerateTree();
    }
    private GameObject CreateBranch(GameObject prevBranch, float angle)
    {
        GameObject branch = Instantiate(prevBranch);
        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;
        branch.transform.rotation *= Quaternion.Euler(0, 0, angle);
        return branch;
    }
}

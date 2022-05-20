using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject branchPrefab;

    [SerializeField]int totalLevels = 2;
    int currentLevel = 0;
    
    Queue<GameObject> frontier = new Queue<GameObject>();

    [SerializeField] private float rootLenght = 4;
    [SerializeField] private float currentLenght = -1;
    [SerializeField] private float reductionLenghtPerLevel = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        currentLenght = rootLenght;

        GameObject root = Instantiate(branchPrefab, transform);
        SetBranchLenght(root, rootLenght);

        frontier.Enqueue(root);
        GenerateTree();
    }

    void GenerateTree()
    {
        if (currentLevel >= totalLevels) return;
        ++currentLevel;
        rootLenght = rootLenght - rootLenght * reductionLenghtPerLevel;

        List<GameObject> createdBranches = new List<GameObject>();
        while(frontier.Count > 0)
        {
            var branch = frontier.Dequeue();

            var leftBranch = CreateBranch(branch, Random.Range(10f, 20f));
            var rightBranch = CreateBranch(branch, Random.Range(-10f, -20f));

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
        GameObject branch = Instantiate(branchPrefab, transform);

        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up * currentLenght;
        Quaternion prevRotation = prevBranch.transform.rotation;

        SetBranchLenght(branch, currentLenght);
        prevRotation *= Quaternion.Euler(0, 0, angle);
        branch.transform.rotation = prevRotation;

        return branch;
    }

    private void SetBranchLenght(GameObject branch, float lenght)
    {
        Transform line = branch.transform.GetChild(0);
        Transform circle = branch.transform.GetChild(1);
        line.localScale = new Vector3(line.localScale.x, lenght, line.localScale.z);
        line.localPosition = new Vector3(0f, lenght * 0.5f, 0f);
        circle.localPosition = new Vector3(0f, lenght, 0f);
    }
    private float GetBranchLength(GameObject branch)
    {
        Transform line = branch.transform.GetChild(0);
        return line.localScale.y;
    }
}

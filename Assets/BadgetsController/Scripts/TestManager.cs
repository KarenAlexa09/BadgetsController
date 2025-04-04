using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] private ResultsModel resultsModel;
    
    [Space, SerializeField] private BadgetsController controller;
    [SerializeField] private TestUIView testUIPrefab;
    [SerializeField] private Transform contentParent;

    private void Start()
    {
        controller.Initialize(resultsModel);
        controller.AssignBadges();

        foreach (var result in resultsModel.GetResults())
        {
            TestUIView view = Instantiate(testUIPrefab, contentParent);
            view.Initialize(result);
        }
    }
}

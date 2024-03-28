namespace SpecPlayApiTest.StepDefinitions;

[Binding]
public class MathOperationsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public MathOperationsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the numbers (.*) and (.*)")]
    public void GivenTheNumbersAnd(int n1, int n2)
    {
        _scenarioContext["n1"] = n1;
        _scenarioContext["n2"] = n2;
    }

    [When(@"I add them using the Math API")]
    public async Task WhenIAddThemUsingTheMathAPI()
    {
        int n1 = Convert.ToInt32(_scenarioContext["n1"]);
        int n2 = Convert.ToInt32(_scenarioContext["n2"]);

        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"https://localhost:7253/api/MathOperations/add?a={n1}&b={n2}");

        _scenarioContext["response"] = response;
    }

    [Then(@"the result must be (.*)")]
    public async Task ThenTheResultMustBe(int expectedSum)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];

        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        var responseInt = Convert.ToInt32(responseContent);

        Assert.Equal(expectedSum, responseInt);
    }
}

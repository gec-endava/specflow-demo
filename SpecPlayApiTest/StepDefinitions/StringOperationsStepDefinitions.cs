using System.Text;

namespace SpecPlayApiTest.StepDefinitions;

[Binding]
public class StringOperationsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public StringOperationsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext; 
    }

    [Given(@"the string ""([^""]*)""")]
    public void GivenTheString(string theString)
    {
        _scenarioContext["string"] = theString;
    }

    [When(@"I invoke Count Chars method")]
    public async Task WhenIInvokeCountCharsMethod()
    {
        var theString = _scenarioContext["string"].ToString();

        using var httpClient = new HttpClient();
        using var content = new StringContent($"\"{theString}\"", Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://localhost:7253/api/StringOperations/count-chars", content);

        _scenarioContext["response"] = response;

    }

    [Then(@"I get response code (.*)")]
    public void ThenIGetResponseCode(int expectedResponseCode)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        Assert.Equal(expectedResponseCode, (int)response.StatusCode);
    }

    [Then(@"I get (.*) in response")]
    public async Task ThenIGetInResponse(int expectedResponse)
    {
        var response = (HttpResponseMessage)_scenarioContext["response"];
        var actualResponse = Convert.ToInt32(await response.Content.ReadAsStringAsync());

        Assert.Equal(expectedResponse, actualResponse);
    }
}
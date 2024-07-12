namespace ExploringReqnroll.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        private PetstoreClient _client;
        private User? _user;
        private User? _createdUser;
        private bool _errorOccured = false;

        public UsersStepDefinitions()
        {
            var httpClient = new HttpClient();
            _client = new PetstoreClient(httpClient);
        }

        [Given("a new user account is created with the following properties")]
        public async Task GivenANewUserAccountIsCreatedWithTheFollowingProperties(DataTable dataTable)
        {
            _user = dataTable.CreateInstance<User>();
            await _client.CreateUserAsync(_user);
        }

        [When("the account details are requested")]
        public async Task WhenTheAccountDetailsAreRequested()
        {
            try
            {
                _createdUser = await _client.GetUserByNameAsync(_user.Username);
            }
            catch
            {
                // Invalid data
            }
        }

        [Then("the (account )details match")]
        public void ThenTheEnteredDetailsAreReturned()
        {
            _createdUser.Should().BeEquivalentTo(_user, options => options.Excluding(p => p.Id).Excluding(p => p.UserStatus));
        }

        [Then("an id has been assigned")]
        public void ThenAnIdHasBeenAssigned()
        {
            _createdUser.Should().NotBeNull();
            _createdUser.Id.Should().NotBeNull();
            _createdUser.Id.Should().BeGreaterThan(0);
        }

        [Then("nothing is returned")]
        public void ThenNothingIsReturned()
        {
            _createdUser.Should().BeNull();
        }


        [Then("the user can login")]
        public async Task ThenTheUserCanLogin()
        {
            await _client.LoginUserAsync(_user.Username, _user.Password);
        }
    }
}

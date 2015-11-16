namespace SP.Twitter
{
    public interface IAuthenticate
    {
        AuthenticationResponse AuthenticateUser(AuthenticationSettings authenticationSettings);
    }
}

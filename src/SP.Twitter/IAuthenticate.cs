namespace SP.Twitter
{
    public interface IAuthenticate
    {
        AuthenticationResponse AuthenticateUser(IAuthenticationSettings authenticationSettings);
    }
}
